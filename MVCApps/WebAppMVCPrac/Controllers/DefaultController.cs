using Microsoft.AspNetCore.Mvc;

namespace WebAppMVCPrac.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index(int id, int a= 10, string b = "default string",int c = 20)
        {
            ViewBag.Id = id;
            ViewBag.A = a;
            ViewBag.B = b;
            ViewBag.C = c;
            return View();
        }
    }
}
