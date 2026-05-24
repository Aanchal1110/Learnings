using CotrollerExample1.Models;
using Microsoft.AspNetCore.Mvc;

namespace CotrollerExample1.Controllers
{
   public class HomeController: Controller
    {
        [Route("Home")]
        [Route("/")]
        public ContentResult Home()
        {
            //return new ContentResult()
            //{
            //    Content="Hello from the method implementing content result directly",ContentType="ruru/plain"
            //};

            return Content("Hello from returning the content using the controller class that is the child class of the ControllerBase class", "text/plain");
        }

        //sendint the content to the browser in the json format
        [Route("Person")]
        public JsonResult PersonDetails()
        {
            Person person = new Person { Id = Guid.NewGuid(), FirstName="Aanchal", LastName="Updhyay", Age=24};
            //return new JsonResult(person); ->this can also be written as below as it is a functiion of BaseController class which is the parent class of the controller class
            return Json(person);

        }

        [Route("file-download")]
        public VirtualFileResult FileDownload()
        {
            //return new VirtualFileResult("/sample.pdf", "application/pdf");  //this can also be written by using the File method of basecontroller class that returns VirtualFileResult same goes for the below 2 methods
            return File("/sample.pdf", "application/pdf");
        }

        [Route("file-download1")]
        public PhysicalFileResult FileDownload1()
        {
            //return new PhysicalFileResult("C:\\Users\\aanch\\Downloads\\dotnet+8+slides.pdf", "application/pdf");
            return PhysicalFile(@"C:\\Users\\aanch\\Downloads\\dotnet+8+slides.pdf", "application/pdf");
        }

        [Route("file-download2")]
        public FileContentResult FileDownload2()
        {
            byte[] bytes = System.IO.File.ReadAllBytes("C:\\Users\\aanch\\Downloads\\dotnet+8+slides.pdf");
            //return new FileContentResult(bytes, "application/pdf");
            return File(bytes, "application/pdf");
        }
    }
}
