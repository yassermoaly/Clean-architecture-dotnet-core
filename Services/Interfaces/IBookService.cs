using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Interfaces
{
    public interface IBookService
    {
        IQueryable<Book> GetAll();
    }
}
