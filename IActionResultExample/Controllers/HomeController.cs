using Microsoft.AspNetCore.Mvc;
using IActionResultExample.Models;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        //bookstore?bookid=1000&isloggedin=true
        //redirect url from /bookstore to store/books
        [Route("bookstore/{bookid?}/{isloggedin?}")]
        public IActionResult Index(int? bookid,[FromRoute]bool? isloggedin, Book book)
        {
            //Book Id should be supplied
            if (bookid.HasValue == false)
            {
                //Response.StatusCode = 400;
                //return Content("Book Id is not supplied");
                
                //return new BadRequestResult();
                
                return BadRequest("Book Id is not supplied");
            }
           
            //Book id should be between 1 to 1000
        //    int bookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);
            if (bookid <= 0)
            {
                //Response.StatusCode = 400;
                //return Content("Book id can not be less than 0");
                return BadRequest("Book id can not be less than 0");
            }
            if (bookid > 1000)
            {
                //return Content("Book id can not be greater than 1000");
                return NotFound("Book id can not be greater than 1000");
            }

            //isloggedin should be true
            if (isloggedin == false)
            {
               // Response.StatusCode = 401;
                //return Content("User must be authenticate");
                return Unauthorized("User must be authenticate");
            }
            return Content($"Book id:{bookid}, Book: {book}", "teext/plain");

            // 302 - Found - RedirectToActionResult
            //return new RedirectToActionResult("Books", "Store", new { }); //302 - Found
            //return RedirectToAction("Books", "Store", new { id = bookId });

            // 301 - Moved Permanently - RedirectToActionResult
            //  return new RedirectToActionResult("Books", "Store", new { },permanent:true); // 301 - Moved Permanently
            //  return RedirectToActionPermanent("Books", "Store", new {id = bookId });

            //302 - Found - LocalRedirectResult
            //return new LocalRedirectResult($"store/books/{bookId}"); //302 - Found
            // return LocalRedirect($"store/books/{bookId}"); //302 - Found

            //301 - Moved - permanently - LocalRedirectResult
            //return new LocalRedirectResult($"store/books/{bookId}", true); //301 - Moved Permanently
            // return LocalRedirect($"store/books/{bookId}"); //301 - Moved Permanently

            //return Redirect($"store/books/{bookId}");  //302 - Found
           // return RedirectPermanent($"store/books/{bookId}");  //302 - Found

        }
    }
}
