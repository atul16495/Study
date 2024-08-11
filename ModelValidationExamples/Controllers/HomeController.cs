using Microsoft.AspNetCore.Mvc;
using ModelValidationExamples.Models;

namespace ModelValidationExamples.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index(Person person)
        {
            if (!ModelState.IsValid)
            {
                // List<string> errorlist = new List<string>();
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                //foreach(var value in ModelState.Values)
                //{
                //    foreach (var error in value.Errors)
                //    {
                //        errorlist.Add(error.ErrorMessage); 
                //    }
                //}
              //string errors = string.Join("\n", errorlist);
                return BadRequest(errors);
            }
            return Content($"{person}");
        }
    }
}
