using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestJulius2Grow.Api.Data.Context;
using TestJulius2Grow.Api.Data.Models;

namespace TestJulius2Grow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookDbContext _context;

        public BooksController(BookDbContext context)
        {
            _context = context;
        }


        #region [ Read All Books/Filter 10]
        /// <summary>
        /// Get all books of 10 in 10
        /// </summary>
        /// <returns>10 books</returns>
        [HttpGet("[action]")]
        public ActionResult<List<Book>> GetAllBooks()
        {

            return Ok(_context.Books.ToList());

        }
        #endregion


        #region [ Create/Add New Book ]
        /// <summary>
        /// Create or Add new book
        /// </summary>
        /// <param name="book"></param>
        /// <returns>new book</returns>
        /// 
        [HttpPost("{AddBook}")]
        public ActionResult<Book> AddBook([FromBody] Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return Ok(book);
        }
        #endregion


        #region [ Update Book ]
        [HttpPut("UpdateBook/{id}")]
        public ActionResult UpdateBook(Book book)
        {
            var bookUpdate = _context.Books.FirstOrDefault(b => b.BookId == book.BookId);
            bookUpdate.Title = book.Title;
            bookUpdate.Description = book.Description;
            bookUpdate.Author = book.Author;
            _context.SaveChanges();

            return Ok(book);
        }
        #endregion


        #region [ Delete Book ]
        [HttpDelete("Delete/{id}")]
        public ActionResult<Book> DeleteBook(int id)
        {
            var bookDelete = _context.Books.FirstOrDefault(b => b.BookId == id);
            _context.Remove(bookDelete);
            _context.SaveChanges();
            return Ok(bookDelete);
        }
        #endregion


        #region [ Single Book by Id ]
        [Route("SingleBook/{id}")]
        [HttpGet]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.BookId == id);
            return Ok(book);
        }
        #endregion
    }
}
