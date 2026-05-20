using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    [Route("book/store/{id}")]
    public class RedirectionController : Controller
    {
        public IActionResult Book()
        {
            int id = Convert.ToInt32(Request.RouteValues["id"]);
            return Content($"hello {id}");
        }
    }
}
