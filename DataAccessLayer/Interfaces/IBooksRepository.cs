using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IBooksRepository : IGenericRepository<Book>
    {
        IQueryable<Book> GetBooksByGenre(string Genre);
    }
}
