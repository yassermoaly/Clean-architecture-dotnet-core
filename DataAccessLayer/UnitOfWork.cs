using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
namespace DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        public DBContext DBContext { get; }
        public IBooksRepository BooksRepository { get; }
        public IUsersRepository UsersRepository { get; }
        public UnitOfWork(DBContext BooksDBContext, IBooksRepository BooksRepository, IUsersRepository UsersRepository)
        {
            this.DBContext = BooksDBContext;
            this.BooksRepository = BooksRepository;
            this.UsersRepository = UsersRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await DBContext.SaveChangesAsync();
        }
    }
}
