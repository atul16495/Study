using Microsoft.AspNetCore.Mvc;

namespace ViewExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        public IActionResult Index()
        {
            return View(); //Views/Home/Index.cshtml
            //return View("abc"); //Home.cshtml
           // return new ViewResult() { ViewName = "abc" };
        }
    }
}
