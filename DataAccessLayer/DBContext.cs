using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Models;
using DataAccessLayer.Interfaces;
using SharedConfig.Constants;

namespace DataAccessLayer
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        { 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Global Filter - IsDeleted

            // User
            modelBuilder.Entity<User>().Property<bool>("IsDeleted");
            modelBuilder.Entity<User>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);

            // Book
            modelBuilder.Entity<Book>().Property<bool>("IsDeleted");
            modelBuilder.Entity<Book>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);


            // SEEDING

            // Book
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = Guid.NewGuid(), Name = "Book 1", IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Book { Id = Guid.NewGuid(), Name = "Book 2", IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Book { Id = Guid.NewGuid(), Name = "Book 3", IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Book { Id = Guid.NewGuid(), Name = "Book 4", IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Book { Id = Guid.NewGuid(), Name = "Book 5", IsDeleted = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
                );
            /*
            // User
            modelBuilder.Entity<User>().HasData(
                new User { Id = Guid.NewGuid(), Name = "User 1", Username = "user.1", Role = AppRole.ADMIN, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new User { Id = Guid.NewGuid(), Name = "User 2", Username = "user.2", Role = AppRole.ADMIN, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new User { Id = Guid.NewGuid(), Name = "User 3", Username = "user.3", Role = AppRole.USER, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new User { Id = Guid.NewGuid(), Name = "User 4", Username = "user.4", Role = AppRole.USER, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new User { Id = Guid.NewGuid(), Name = "User 5", Username = "user.5", Role = AppRole.USER, IsDeleted = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
                );
            */
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
