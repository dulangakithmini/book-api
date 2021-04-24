using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}