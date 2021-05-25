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

namespace Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork UnitOfWork;
        public BookService(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }
        public async Task<List<Book>> GetAll()
        {
            List<Book> data = await UnitOfWork.BooksRepository.GetAllBooks();
            // TODO: format data here before returning to controller
            return data;
        }
    }
}
