using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        Task<User> GetUserByUsernameAndPassword(string username, byte[] password);
    }
}
