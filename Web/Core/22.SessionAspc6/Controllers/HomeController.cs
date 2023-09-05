using Microsoft.AspNetCore.Mvc;
using SessionAspc6.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace SessionAspc6.Controllers
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
            HttpContext.Session.SetString("YourSessionKey", "Aspc6");
            TempData["SessionID"] = HttpContext.Session.Id;

            return View();
        }

        public IActionResult About()
        {
            //if(HttpContext.Session.GetString("YourSessionKey") != null)
            //{
            //    ViewBag.Data = HttpContext.Session.GetString("YourSessionKey");
            //}
            return View();
        }
        
        public IActionResult Details()
        {
            if (HttpContext.Session.GetString("YourSessionKey") != null)
            {
                ViewBag.Data = HttpContext.Session.GetString("YourSessionKey");
            }
            return View();
        }

        public IActionResult Logout()
        {
            if(HttpContext.Session.GetString("YourSessionKey") != null)
            {
                HttpContext.Session.Remove("YourSessionKey");
            }
            return View();
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