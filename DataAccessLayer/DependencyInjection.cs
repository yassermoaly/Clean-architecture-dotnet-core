using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models;
using SharedConfig.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterDataAccessLayer(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();          
            services.AddDbContext<DBContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }
}
