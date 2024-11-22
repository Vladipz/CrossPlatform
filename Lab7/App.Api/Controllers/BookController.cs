using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly SpecialistBookshopDbContext _context;

        public BookController(SpecialistBookshopDbContext context)
        {
            _context = context;
        }

        // GET: api/Book
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.BookCategory)
                .ToListAsync();
            return Ok(books);
        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.BookCategory)
                .FirstOrDefaultAsync(m => m.BookId == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST: api/Book
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBook), new { id = book.BookId }, book);
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            if (id != book.BookId)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }
    }

    [ApiController]
    public class BookVersionedController : ControllerBase
    {
        private readonly SpecialistBookshopDbContext _context;

        public BookVersionedController(SpecialistBookshopDbContext context)
        {
            _context = context;
        }

        // V1: Basic book info
        [HttpGet]
        [Route("api/v1/books")]
        public async Task<IActionResult> GetBooksV1()
        {
            var books = await _context.Books
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.Price
                })
                .ToListAsync();
            return Ok(books);
        }

        // V1: Get book by id
        [HttpGet]
        [Route("api/v1/books/{id}")]
        public async Task<IActionResult> GetBookV1(int id)
        {
            var book = await _context.Books
                .Where(b => b.BookId == id)
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.Price
                })
                .FirstOrDefaultAsync();

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // V2: Enhanced book info (includes author and category)
        [HttpGet]
        [Route("api/v2/books")]
        public async Task<IActionResult> GetBooksV2()
        {
            var books = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.BookCategory)
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.Price,
                    Author = new { b.Author.Name },
                    Category = new { b.BookCategory.Name },
                    b.ISBN,
                    b.Description
                })
                .ToListAsync();
            return Ok(books);
        }

        // V2: Get book by id with enhanced info
        [HttpGet]
        [Route("api/v2/books/{id}")]
        public async Task<IActionResult> GetBookV2(int id)
        {
            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.BookCategory)
                .Where(b => b.BookId == id)
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.Price,
                    Author = new { b.Author.Name },
                    Category = new { b.BookCategory.Name },
                    b.ISBN,
                    b.Description
                })
                .FirstOrDefaultAsync();

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
    }
}