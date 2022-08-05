using BookSellingAssessment_API_.Data;
using BookSellingAssessment_API_.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookSellingAssessment_API_.Controllers
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

        #region GET METHOD

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBookDetails()
        {
          if (_context.BookDetails == null)
          {
              return NotFound();
          }
            return await _context.BookDetails.ToListAsync();
        }
        #endregion

        #region SEARCH METHOD

        [HttpGet("{searchString}")]
        public async Task<IActionResult> ShowOneBook(string searchString)
        {
            if (searchString == null)
            {
                return BadRequest("input can't be null");
            }
            if (_context.BookDetails == null)
            {
                return NotFound("Table doesn't exists");
            }
            var book = await _context.BookDetails.Where(e => e.Name.Contains(searchString) || e.Zoner.Contains(searchString)).ToListAsync();
            if (book == null)
            {
                return NotFound("Record doesn't exists");
            }
            return Ok(book);
        }

        //// GET: api/Books
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Book>> GetBook(int id)
        //{
        //  if (_context.BookDetails == null)
        //  {
        //      return NotFound();
        //  }
        //    var book = await _context.BookDetails.FindAsync(id);

        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    return book;
        //}

        #endregion

        #region PUT METHOD

        // PUT: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
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
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        #endregion

        #region POST METHOD

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
          if (_context.BookDetails == null)
          {
              return Problem("Entity set 'BookDbContext.BookDetails'  is null.");
          }
            _context.BookDetails.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        #endregion

        #region DELETE METHOD

        // DELETE: api/Books
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (_context.BookDetails == null)
            {
                return NotFound();
            }
            var book = await _context.BookDetails.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.BookDetails.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion
        private bool BookExists(int id)
        {
            return (_context.BookDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
