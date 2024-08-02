using Microsoft.AspNetCore.Mvc;
using ControllersExamples.Models;

namespace ControllersExamples.Controllers
{
    [Controller]
    public class HomeController: Microsoft.AspNetCore.Mvc.Controller
    {
        [Route("home")]
        [Route("/")]
        public ContentResult Index()
        {
            //return  new ContentResult()
            //{ Content = "Hello from Index", ContentType="text/plain" };
            return Content("Hello From Index", "text/plain");
        }
        [Route("person")]
        public JsonResult Person()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(), FirstName = "Atul", LastName = "Dafale", Age = 25
            };
            return new JsonResult(person);
        }

        [Route("file-download")]
        public VirtualFileResult FileDownload()
        {
            //return new VirtualFileResult("/Atul_Dafale_2021.pdf", "application/pdf");
            return File("/Atul_Dafale_2021.pdf", "application/pdf");
        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownload2()
        {
            //return new PhysicalFileResult(@"D:\Resume\2021\Atul_Dafale_2021.pdf", "application/pdf");
            return PhysicalFile(@"D:\Resume\2021\Atul_Dafale_2021.pdf", "application/pdf");
        }

        [Route("file-download3")]
        public IActionResult FileDownload3()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"D:\Resume\2021\Atul_Dafale_2021.pdf");
            //     return new FileContentResult(bytes, "application/pdf");
            return File(bytes, "application/pdf");

        }

        [Route("sayhello")]
        public string method1()
        {
            return "Hello from method1";
        }
    }
} 
