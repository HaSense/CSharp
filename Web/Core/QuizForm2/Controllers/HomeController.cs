using Microsoft.AspNetCore.Mvc;

namespace WebEmptyDday.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Result(string str1,  string str2)
        {
            ViewBag.Result1 = str1;
            ViewBag.Result2 = str2;

            return View();
        }
    }
}
