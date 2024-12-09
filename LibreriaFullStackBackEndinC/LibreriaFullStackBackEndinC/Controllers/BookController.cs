using LibreriaFullStackBackEndinC.Contexts;
using LibreriaFullStackBackEndinC.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibreriaFullStackBackEndinC.Controllers
{
    [ApiController]
    [Route("book")]
    [EnableCors("AllowSpecificOrigin")]
    public class BookController : ControllerBase
    {
        private readonly BookDBContext _dbContext;

        public BookController(BookDBContext bookDBContext)
        {
            this._dbContext = bookDBContext;
        }

        [HttpGet]
        public async Task<IActionResult> getAllBooks()
        {
            var books = await _dbContext.Books.ToListAsync<BookModel>();
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BookModel>> getBookById(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<BookModel>> saveBook([FromBody] BookModel book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            _dbContext.Books.Add(book);
            //_dbContext.InsertBook(book.title,book.author,book.pages,book.price);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(getBookById), new { id = book.id }, book);
        }

        [HttpPut]
        public async Task<ActionResult<BookModel>> updateBook(BookModel book)
        {
            if (book != null)
            {
                _dbContext.Books.Update(book);
                await _dbContext.SaveChangesAsync();
                return CreatedAtAction("getBookById", new { id = book.id }, book);
            }
            else { return BadRequest(); }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteBookById(int id)
        {
            var bookToDelete = await _dbContext.Books.FindAsync(id);
            if (bookToDelete != null)
            {
                _dbContext.Books.Remove(bookToDelete);
                await _dbContext.SaveChangesAsync();
                return NoContent();
            }
            else { return NotFound(); }
        }
        [HttpGet("{title}")]
        public async Task<ActionResult<IEnumerable<BookModel>>> getBooksByTitle(string title)
        {
            var books = await _dbContext.Books.Where(b => b.title.Contains(title)).ToListAsync();

            if (books == null || books.Count == 0)
            {
                return NotFound();
            }
            return Ok(books);
        }
    }
}
