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
using SharedConfig.Config;
using SharedConfig.Constants;

namespace Services
{
    public class SecurityService : ISecurityService
    {
        private readonly AppConfig _config;
        public SecurityService(AppConfig config)
        {
            _config = config;
        }
        public byte[] CreatePasswordHash(string password)
        {
            if (password == null) throw new AppException(Errors.E_PASSWORD_NOT_VALID, new { password }, AppObjects.PASSWORD);
            if (string.IsNullOrWhiteSpace(password)) throw new AppException(Errors.E_VALUE_CANNOT_BE_EMPTY_OR_WHTIESPACE, new { password }, AppObjects.PASSWORD);

            using System.Security.Cryptography.HMACSHA512 hmac = new();
            hmac.Key = Encoding.UTF8.GetBytes(_config.Keys.PasswordSalt);
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return passwordHash;
        }
    }
}
