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
    public class BooksRepository : GenericRepository<Book>, IBooksRepository
    {
        private readonly DBContext _context;
        public BooksRepository(DBContext context, AppConfig config) : base(context, config)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookById(Guid Id)
        {
            return await _context.Books.Where(book => book.Id == Id).FirstOrDefaultAsync();
        }

    }
}
