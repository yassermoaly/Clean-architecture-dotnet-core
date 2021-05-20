using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Models;
using System.Linq;

namespace DataAccessLayer
{
    public class BooksRepository : GenericRepository<Book>, IBooksRepository
    {
        private readonly BooksDBContext _context;
        public BooksRepository(BooksDBContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Book> GetBooksByGenre(string Genre)
        {
            return _context.Books.Where(x => x.Id == 1);
        }

    }
}
