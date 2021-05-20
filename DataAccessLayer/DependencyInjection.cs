using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterDataAccessLayer(this IServiceCollection services)
        {
            services.AddTransient<IBooksRepository, BooksRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();          
            services.AddDbContext<BooksDBContext>(options => options.UseSqlServer(@"Server=YASSER_MOLY1\SQLEXPRESS; Database=BooksDB;User Id=sa; Password=123456;"));
            return services;
        }
    }
}
