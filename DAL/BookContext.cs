using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BookContext:DbContext
    {
        
        public BookContext(DbContextOptions contextOptions) : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>()
                .HasOne<Author>(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.CodeAuthor);

            modelBuilder.Entity<Book>()
                .HasOne<Publisher>(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.CodePublisher);


            modelBuilder.Entity<Author>()
                .HasData(
                    new Author
                    {
                        Code = "1",
                        Name = "Robi Shama",
                    },
                    new Author
                    {
                        Code = "2",
                        Name = "Stephen W Hawking",
                    },
                    new Author
                    {
                        Code = "3",
                        Name = "Robert T. Kiyosaki",
                    }
                );

            modelBuilder.Entity<Publisher>()
                .HasData(
                    new Publisher
                    {
                        Code = "1",
                        Name = "Jaiko Publishing House"
                    },
                    new Publisher
                    {
                        Code = "2",
                        Name = "Jaiko Publishing House"
                    },
                    new Publisher
                    {
                        Code = "3",
                        Name = "Plata Publishing"
                    }
                );


            modelBuilder.Entity<Book>()
                .HasData(
                    new Book 
                    {
                        Reference = "0000",
                        Title = "The Monk Who Sold His Ferrari",
                        CodePublisher = "1",
                        CodeAuthor = "1",
                        Genre = "Fiction",
                        Price = 141
                    },
                    new Book
                    {
                        Reference = "0001",
                        Title = "The Theory Of Everything",
                        CodePublisher = "2",
                        CodeAuthor = "2",
                        Genre = "Engineering & Technology",
                        Price = 149
                    },
                    new Book
                    {
                        Reference = "0002",
                        Title = "Rich Dad Poor Dad",
                        CodePublisher = "3",
                        CodeAuthor = "3",
                        Genre = "Personal Finance",
                        Price = 288
                    }
                );
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

    }
}
