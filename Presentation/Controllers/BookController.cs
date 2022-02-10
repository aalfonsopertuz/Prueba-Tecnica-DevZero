using BLL;
using DAL;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService bookService;

        public BookController(BookContext bookContext)
        {
            bookService = new BookService(bookContext);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            var response = bookService.Consult();
            if (response.Error == true)
                return BadRequest(response.Mensaje);
            return Ok(response.Books);
        }

        [HttpGet("{reference}")]
        public ActionResult<IEnumerable<Book>> GetReference(string reference)
        {
            var response = bookService.ConsultReference(reference);
            if (response.Error == true)
                return BadRequest(response.Mensaje);
            return Ok(response.Book);
        }

        [HttpPost]
        public ActionResult<Book> Post(BookInputModels bookInput)
        {
            var book = mapearBook(bookInput);
            var response = bookService.Save(book);
            if (response.Error)
                return BadRequest(response.Mensaje);
            return Ok(response.Book);
        }

        private Book mapearBook(BookInputModels bookInput)
        {
            var book = new Book
            {
                Reference = bookInput.Reference,
                Title = bookInput.Title,
                CodePublisher = bookInput.CodePublisher,
                CodeAuthor = bookInput.CodeAuthor,
                Genre = bookInput.Genre,
                Price = bookInput.Price
            };
            return book;
        }

        [HttpPut("{reference}")]
        public ActionResult<Book> Put(string reference, BookInputModels bookInput)
        {
            var book = mapearBook(bookInput);
            var reponse = bookService.Edit(reference, book);
            if (reponse.Error)
                return BadRequest(reponse.Mensaje);
            return Ok(reponse.Book);
        }

        [HttpDelete("{reference}")]
        public ActionResult<Book> Delete(string reference)
        {
            var response = bookService.Remove(reference);
            if (response.Error)
                return BadRequest(response.Mensaje);

            return Ok(response.Book);
        }



    }
}
