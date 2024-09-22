using Microsoft.AspNetCore.Mvc;
using ModelValidationExamples.CustomModelBinder;
using ModelValidationExamples.Models;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationExamples.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        // public IActionResult Index([Bind(nameof(Person.PersonName),nameof(Person.Email),nameof(Person.Password),nameof(Person.ConfirmPassword))] Person person)
        // public IActionResult Index([FromBody][ModelBinder(BinderType=typeof(PersonModelBinder))]Person person)
        public IActionResult Index(Person person, [FromHeader(Name = "User-Agent")] string UserAgent)
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
