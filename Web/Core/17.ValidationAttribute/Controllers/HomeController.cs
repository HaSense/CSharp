using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ValidationAttributesTest.Models;

namespace ValidationAttributesTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Student std)
        {
            return View();
        }

        //[HttpPost]
        //public string Index(Student std)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        return "이름 : " + std.Name;
        //    }
        //    else
        //    {
        //        return "검증 실패...";
        //    }

        //}

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