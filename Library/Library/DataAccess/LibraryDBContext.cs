using Library.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DataAccess
{
    public class LibraryDBContext : DbContext
    {
        public DbSet<Books> Books { get; set; }
        public DbSet<Users> User { get; set; }

        public LibraryDBContext()
        {

        }

        public LibraryDBContext(DbContextOptions<LibraryDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasMany(a => a.Books)
                      .WithOne(a => a.User)
                      .HasForeignKey(a => a.UserID);
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(a => a.ISBN);
            });

            base.OnModelCreating(modelBuilder);
                 
        }
    }
}
