using System.Collections.Generic;
using System.Threading.Tasks;
using BookAPI.Models;
using BookAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // When this method is invoked, asp.net concerts book object to json before returning it.
        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.Get();
        }

        // ActionResult provides the flexibility to return other types such as not found or bad request.
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBooks(int id)
        {
            return await _bookRepository.Get(id);
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}