using System.Linq;
using App.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utils;

namespace App.Controllers
{
    // [Authorize]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Books?.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Store(string title, string description)
        {
            var book = new Book(title, description);

            if (!ModelState.IsValid) return View();

            _context.Books?.Add(book);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}