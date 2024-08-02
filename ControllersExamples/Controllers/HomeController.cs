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

        [Route("sayhello")]
        public string method1()
        {
            return "Hello from method1";
        }
    }
} 
