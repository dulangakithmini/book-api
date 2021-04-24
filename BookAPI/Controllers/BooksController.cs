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

        // Model binding -> [FromBody] Book book
        // With this, Asp.net convert a json in the request payload to a book object
        [HttpPost]
        public async Task<ActionResult<Book>> PostBooks([FromBody] Book book)
        {
            var newBook = await _bookRepository.Create(book);
            return CreatedAtAction(nameof(GetBooks), new {id = newBook.Id}, newBook);
        }

        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            await _bookRepository.Update(book);
            // Generate 201 http status code to indicate that the request has been processed but there's no data.
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBooks(int id)
        {
            var bookToDelete = _bookRepository.Get(id);

            if (bookToDelete == null)
            {
                return NotFound();
            }

            await _bookRepository.Delete(bookToDelete.Id);
            return NoContent();
        }
    }
}