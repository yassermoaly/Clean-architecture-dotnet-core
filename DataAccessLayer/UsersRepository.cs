using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Models;
using System.Linq;
using SharedConfig.Config;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        private readonly DBContext _context;
        public UsersRepository(DBContext context, AppConfig config) : base(context, config)
        {
            _context = context;
        }
     
        public async Task<User> GetUserByUsernameAndPassword(string username, byte[] password)
        {
            return await _context.Users.Where(user => user.Username == username && user.Password == password).IgnoreQueryFilters().FirstOrDefaultAsync();
        }

    }
}
