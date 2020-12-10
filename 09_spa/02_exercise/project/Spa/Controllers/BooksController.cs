using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spa.Data;

namespace Spa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            // var book = new Book(name, author, publisher, year); 
            return CreatedAtAction("ListBooks", new {name = book.Name}, _context.Books.Add(book));
        }

        [HttpGet]
        public IEnumerable<Book> ListBooks()
        {
            return _context.Books.ToArray();
        }
    }
}