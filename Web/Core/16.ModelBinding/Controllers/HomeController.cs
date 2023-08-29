using Microsoft.AspNetCore.Mvc;
using ModelBindingTest.Models;
using System.Diagnostics;

namespace ModelBindingTest.Controllers
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
        public string Index(Student st)
        {
            return "Id:"+st.Id +" Name:"+st.Name + " Hp:"+st.Hp;
        }

        public string Details(int id, string name)
        {
            return "Id is: " + id + " Name is: " + name;
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