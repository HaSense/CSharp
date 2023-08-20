using Microsoft.AspNetCore.Mvc;

namespace RoutingWithoutMVC.Controllers
{
    //[Route("Home")]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [Route("")]
        //[Route("Index")]
        [Route("[action]")]
        [Route("~/")]
        public IActionResult Index()
        {
            return View();
        }

        //[Route("About")]
        [Route("[action]")]
        public IActionResult About()
        {
            return View();
        }

        //[Route("Details/{id?}")]
        [Route("[action]/{id?}")]
        public int Details(int? id)
        {
            return id ?? 1;
        }

        //public ViewResult Details(int id)
        //{
        //    return View();
        //}
    }
}
