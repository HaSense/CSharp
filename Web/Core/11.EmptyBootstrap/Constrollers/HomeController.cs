using Microsoft.AspNetCore.Mvc;

namespace EmptyBootstrap.Constrollers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
