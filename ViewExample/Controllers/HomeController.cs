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
            //ViewData["people"]=people;
            //ViewBag.people = people;

            return View("Index",people); //Views/Home/Index.cshtml
            //return View("abc"); //Home.cshtml
           // return new ViewResult() { ViewName = "abc" };
        }

        [Route("person-details/{name}")]
        public IActionResult Details(string? name, Person temp)
        {
            if(name == null)            
              return Content("Person Name can not be null");
           
            List<Person> people = new List<Person>()
             {
             new Person(){Name="Atul",DateOfBirth=DateTime.Parse("2002-05-06"),PersonGender = Gender.Male},
             new Person() {Name = "jon", DateOfBirth = DateTime.Parse("2005-09-06"), PersonGender = Gender.Female },
             new Person(){Name="boss",DateOfBirth=null,PersonGender = Gender.other}
             };
            Person? matchingPerson = people.Where(temp => temp.Name == name).FirstOrDefault();
            return View(matchingPerson);  //View/Home/Details.cshtml
        }

        [Route("perrson-with-product")]
        public IActionResult PersonWithProduct()
        {
            Person person = new Person() { Name ="star", PersonGender = Gender.Female, DateOfBirth= Convert.ToDateTime("2002-07-01") };
            Product product = new Product() { ProductID = 1, ProductName = "Air Conditioner" };
            PersonAndProductWrapperModel personAndProductWrapperModel = new PersonAndProductWrapperModel() { PersonData = person, ProductData = product };
            return View(personAndProductWrapperModel);
        }

        [Route("home/all-products")]
        public IActionResult All()
        {
            return View();
            //views/Home/All.cshtml
            //views/Shared/All.cshtml
        }

    }
}
