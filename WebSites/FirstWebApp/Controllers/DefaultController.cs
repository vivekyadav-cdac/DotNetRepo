using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index(int ?id,int c=3,int b=2, int a=1)// here variable name should be same as the id(var) name in root variable
        {
            if(id == null)
                return NotFound();// here IActionResult i returning NotFound() class 
            ViewBag.Id = id;
            ViewBag.C = c;
            ViewBag.B = b;
            ViewBag.A = a;
            return View();
        }
    }
}
// if we dont make the id nullable then  if we don't pass it a value then to it shows 0 as well as on passing as 0
// so make it nullable by giving it ?

// todo - five status code result 

/*
 * Ok()            ---> HTTP 200 -Success
 * NotFound()      ---> HTTP 404 -Resource not found
 * BadRequest()    ---> HTTP 400 -Invalid input
 * Unauthorized()  ---> HTTP 401 -Not logged in
 * StatusCode(500) ---> HTTP 500 -Internal server error
 */

// todo - ten IActionResult classes

/*
 * 1. View()             -> Return a View Page
 * 2. Json()             -> Return JSON data
 * 3. Content()          -> Return plain text
 * 4. File()             -> Return a file for download
 * 5. Redirect()         -> Redirect to another URL
 * 6. RedirectToAction() -> Redirect to another Action
 * 7. PartialView()      -> Return partial view
 * 8. BadRequest()       -> Return 400 Bad Request
 * 9. NotFound()         -> Return 400 Not found
 * 10.Ok()               -> Return 200 OK with optional object
 */


// public IActionResult Index(int ?id,int c,int b, int a) here order not important b/c name binding
// to pass only c in url //
// here we will have to make the value have default values

// to pass something from controller to the view use object ViewBag --> uses dynamic coding i.e. properties can be added at runtime
// viewbag initially has new properties they can be added at runtime
// internally it is a class called expando object -> allows to create properties at runtime.