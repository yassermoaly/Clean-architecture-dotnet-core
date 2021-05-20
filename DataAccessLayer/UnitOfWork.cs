using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Interfaces;
namespace DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBooksRepository BooksRepository { get; }
        public BooksDBContext BooksDBContext { get; }
        public UnitOfWork(BooksDBContext BooksDBContext, IBooksRepository BooksRepository)
        {
            this.BooksRepository = BooksRepository;
            this.BooksDBContext = BooksDBContext;
        }

        public int SaveChanges()
        {
            return this.BooksDBContext.SaveChanges();
        }
    }
}
