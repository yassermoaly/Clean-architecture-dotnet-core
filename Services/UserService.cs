using DataAccessLayer.Interfaces;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using GlobalHelpers.Helpers;
using SharedConfig.Messages;
using SharedConfig.Constants;
using Models.ViewModels;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly ISecurityService _securityService;
        public UserService(IUnitOfWork UnitOfWork, ISecurityService securityService)
        {
            this.UnitOfWork = UnitOfWork;
            _securityService = securityService;
        }

        public async Task<User> CreateUser(VmUserCreate vmUserCreate)
        {
            #region Validate Username
            User similerUser = await UnitOfWork.UsersRepository.Where(user => user.Username == vmUserCreate.Username).FirstOrDefaultAsync();
            if (similerUser != null)
                throw new AppException(Errors.E_USERNAME_IS_TAKEN, new { vmUserCreate.Username }, AppObjects.USERNAME);
            #endregion

            User user = new()
            {
                Name = vmUserCreate.Name,
                Username = vmUserCreate.Username,
                Role = AppRole.USER
            };
            user.Password = _securityService.CreatePasswordHash(vmUserCreate.Password);
            await UnitOfWork.UsersRepository.AddAsync(user);
            await UnitOfWork.SaveChangesAsync();
            return user;
        }

        public async Task<User> ValidateUserToLogin(string username, string password)
        {
            byte[] passwordHash = _securityService.CreatePasswordHash(password);
            User user = await UnitOfWork.UsersRepository.GetUserByUsernameAndPassword(username, passwordHash);
            
            if (user == null)
                throw new AppException(Errors.E_INVALID_USERNAME_OR_PASSWORD);

            if (user.IsDeleted)
                throw new AppException(Errors.E_USER_IS_INACTIVE);

            return user;
        }
    }
}
