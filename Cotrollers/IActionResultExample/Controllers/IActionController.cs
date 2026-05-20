using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class IActionController : Controller
    {
        [Route("book")]
        public IActionResult Index()

        {
           
            if (!Request.Query.ContainsKey("bookid"))
            {
                //Response.StatusCode = 400;
                //return Content("Query should contain book id");

                return BadRequest("Query should contain book id");

            }

            if (string.IsNullOrEmpty(Convert.ToString((Request.Query["bookid"])))){

                //Response.StatusCode = 400;
                //return Content("Bookid cannnot be empty");
                return StatusCode(401);
            }
           int bookid=Convert.ToInt32(Request.Query["bookid"]);
            if (bookid <= 0)
            {
                //Response.StatusCode = 400;
                //return Content("Book id should be greater than 0");
                return BadRequest("Book id should be greater than 0");
            }
            if (bookid >= 1000)
            {
                //Response.StatusCode = 400;
                //return Content("Book id should be less than 1000");
                return new BadRequestObjectResult("Book id shouuld be less than 100");
            }
            if (!Request.Query.ContainsKey("isloggedin"))  // ✅ fixed typo
            {
                Response.StatusCode = 401;
                return Content("User must be logged in");
            }

            if (Request.Query["isloggedin"] != "true")  // ✅ fixed logic
            {
                //Response.StatusCode = 401;
                //return Content("User must be logged in");
                return new NotFoundObjectResult("User must be logged in");
            }

            return File(@"/sample.pdf", "application/pdf");
            
        }
    }
}
