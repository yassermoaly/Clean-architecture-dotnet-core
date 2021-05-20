using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Models;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer
{
    public class BooksDBContext : DbContext
    {
        public BooksDBContext(DbContextOptions<BooksDBContext> options) : base(options)
        { 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
       
        public DbSet<Book> Books { get; set; }
    }
}
