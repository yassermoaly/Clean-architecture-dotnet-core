using Models;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task<User> ValidateUserToLogin(string username, string password);
        Task<User> CreateUser(VmUserCreate vmUserCreate);
    }
}
