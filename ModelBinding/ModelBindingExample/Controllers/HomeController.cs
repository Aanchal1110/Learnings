using Microsoft.AspNetCore.Mvc;
using ModelBindingExample.Models;

namespace ModelBindingExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("Register")]
        public IActionResult Index(Person person)
        {

            return Content($"{person}");
        }
    }
}
