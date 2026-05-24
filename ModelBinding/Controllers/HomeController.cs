using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        //http://localhost:5013/bookstore/?bookid=10&isloggedin=true

        [Route("bookstore/{bookid?}/{isloggedin?}")]
        public IActionResult Index([FromQuery]int? bookid, [FromRoute]bool? isloggedin, Book book)
        {
            if (bookid.HasValue == false)
            {
                return StatusCode(400, "Book Id is required");
            }
            if (bookid <= 0)
            {
                return StatusCode(401, "Book Id must be greater than 0");
            }
            if (bookid >= 1000)
            {
                return StatusCode(402, "Book Id mustn't be greater than 1000");
            }

            if (isloggedin.HasValue == false)
            {
                return StatusCode(403, "IsLoggedIn is required");
            }

            return Content($"User logged in with Id - {bookid}, {book}");
        }
    }
}
