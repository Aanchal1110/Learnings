using Microsoft.AspNetCore.Mvc;
using ModelBindingExample.Models;

namespace ModelBindingExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("Register")]
        public IActionResult Index(Person person)
        {

            if (!ModelState.IsValid)
            {
                //List<string> errors = new List<string>();
                //    foreach(var value in ModelState.Values)
                //    {
                //        foreach(var error in value.Errors)
                //        {
                //            errors.Add(error.ErrorMessage);
                //        }
                //    }
                //    string errorsstring=string.Join("\n", errors
                //        );
                //    return Content(errorsstring);
                //}

                //above can also be written as below

                List<string> errorList = ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage).ToList();

                string errorstring = string.Join("\n", errorList);

                return Content(errorstring);

                    }
            
            return Content($"{person}");
        }
    }
}
