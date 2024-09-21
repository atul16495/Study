using Microsoft.AspNetCore.Mvc;
using ViewExample.Models;

namespace ViewExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["appTitle"] = "Asp.Net Core Demo App";
            List<Person> people = new List<Person>()
             {
             new Person(){Name="Atul",DateOfBirth=DateTime.Parse("2002-05-06"),PersonGender = Gender.Male},
             new Person() { Name = "jon", DateOfBirth = DateTime.Parse("2005-09-06"), PersonGender = Gender.Female },
             new Person(){Name="boss",DateOfBirth=DateTime.Parse("2006-05-20"),PersonGender = Gender.other}
             };
            ViewData["people"]=people;
            return View(); //Views/Home/Index.cshtml
            //return View("abc"); //Home.cshtml
           // return new ViewResult() { ViewName = "abc" };
        }
    }
}
