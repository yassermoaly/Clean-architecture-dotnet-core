using DataAccessLayer.Interfaces;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
namespace Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork UnitOfWork;
        public BookService(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }
        public IQueryable<Book> GetAll()
        {
            return UnitOfWork.BooksRepository.Where(r => r.Id > 0);
        }
    }
}
