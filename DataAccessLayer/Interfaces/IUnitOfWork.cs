using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IBooksRepository BooksRepository { get; }

        int SaveChanges();
    }
}
