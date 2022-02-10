using DAL;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BookService
    {
        private readonly BookContext bookContext;
        public BookService(BookContext bookContext)
        {
            this.bookContext = bookContext;
        }

        public BookResponse Save(Book book)
        {
            try
            {
                var registeredBook = bookContext.Books.Find(book.Reference);
                if (registeredBook != null)
                {
                    return new BookResponse ("Registered Book");
                }
                bookContext.Books.Add(book);
                bookContext.SaveChanges();
                return new BookResponse(book);
            }
            catch (Exception e)
            {
                return new BookResponse("Application Error: "+e.Message);
            }
        }

        public ConsultBooksResponse Consult()
        {
            try
            {
                List<Book> books = bookContext.Books.Include(a => a.Author).Include(p => p.Publisher).ToList();
                if (books == null)
                {
                    return new ConsultBooksResponse("Empty list");
                }
                return new ConsultBooksResponse (books);

            }
            catch (Exception e) 
            {
                return new ConsultBooksResponse("Application Error: " + e.Message);
            }
        }

        public BookResponse ConsultReference(string reference)
        {
            try
            {
                Book book = bookContext.Books.Find(reference);
                if (book == null)
                {
                    return new BookResponse("Empty list");
                }
                return new BookResponse(book);

            }             

            catch (Exception e)
            {
                return new BookResponse("Application Error: " + e.Message);
            }
        }


        public BookResponse Remove(string reference)
        {
            try
            {
                var registeredBook = bookContext.Books.Find(reference);
                if (registeredBook != null)
                {
                    bookContext.Books.Remove(registeredBook);
                    bookContext.SaveChanges();
                    return new BookResponse(registeredBook);
                }
                else
                {
                    return new BookResponse($"Reference Book {reference} not found");
                }
            }
            catch (Exception e)
            {
                return new BookResponse("Application Error: " + e.Message);
            }
        }

        public BookResponse Edit(string reference, Book newBook)
        {
            try
            {
                var oldBook = bookContext.Books.Find(reference);
                var oldAuthor = bookContext.Authors.Find(newBook.CodeAuthor);
                var oldPublisher = bookContext.Publishers.Find(newBook.CodePublisher);
                if (oldBook != null)
                {
                    if (oldAuthor != null)
                    {
                        if (oldPublisher != null)
                        {
                            oldBook.Title = newBook.Title;
                            oldBook.Genre = newBook.Genre;
                            oldBook.Price = newBook.Price;
                            oldBook.CodeAuthor = newBook.CodeAuthor;
                            oldBook.CodePublisher = newBook.CodePublisher;
                            bookContext.Books.Update(oldBook);
                            bookContext.SaveChanges();
                            return new BookResponse (oldBook);
                        }
                        else
                        {
                            return new BookResponse ($"Code Publisher {newBook.Reference} not found");
                        }
                    }
                    else
                    {
                        return new BookResponse ($"Code Author {newBook.Reference} not found");
                    }
                }
                else
                {
                    return new BookResponse ($"Reference Book {newBook.Reference} not found");
                }
            }
            catch (Exception e)
            {
                return new BookResponse ("Application Error: " + e.Message);
            }
        }
    }

    public class BookResponse
    {
        public Book Book { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public BookResponse(Book book)
        {
            this.Book = book;
            this.Error = false;
        }

        public BookResponse(string mensaje)
        {
            this.Mensaje = mensaje;
            this.Error = true;
        }
    }

    public class ConsultBooksResponse
    {
        public List<Book> Books { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ConsultBooksResponse(List<Book> books)
        {
            this.Books = books;
            this.Error = false;
        }

        public ConsultBooksResponse(string mensaje)
        {
            this.Mensaje = mensaje;
            this.Error = true;
        }
    }
}
