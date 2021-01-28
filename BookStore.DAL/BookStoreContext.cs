using BookStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext() : base("BookStoreDb")
        {
            //Database.SetInitializer(new BookStoreInitializer());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Order> Purchases { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasMany(x => x.Authors)
                .WithMany(x => x.Books);

            modelBuilder.Entity<Book>()
                .HasMany(x => x.Genres)
                .WithMany(x => x.Books);

            modelBuilder.Entity<Book>()
                .HasMany(x => x.Orders)
                .WithMany(x => x.Books);
        }
    }
}
