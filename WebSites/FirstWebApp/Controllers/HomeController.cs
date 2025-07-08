using System.Diagnostics;
using FirstWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp.Controllers 
{

    // convention --> whenever naming a controller it has to have a suffix of Controller, otherwise code will not work, Here --> HomeController
    public class HomeController : Controller // base class for mvc controller with view support, also ControllerBase--> no view support, also there are many ControllerBase classes
    {
        private readonly ILogger<HomeController> _logger;

        // concept --> using dependency injection , using constructor injection
        public HomeController(ILogger<HomeController> logger)// asp.net mvc core is passing it, using constructor dependency injection
        {
            _logger = logger;// helps to log everything 
        }

        // action method corresponds to url typically
        public IActionResult Index() // home is pointing to this Index action and it is returning view (should return viewresult but viewresult extends ActionResult which in turn implements IActionResult
        {
            // this (returning IActionResult) is done because viewresult is one of many things that can be returned from here -> todo: read upon derived classes of action result
            return View();
            // if we give some name to view -> return View("SomeViewName") , then it searches for that view, otherwise it searches for Method name i.e. Index
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
// if a view is being used by more than one controller than it will be put in the shared folder in the views
//otherwise put under the view with that view name
// razor code c# code will be written in the @{} inside the .cshtml file of views