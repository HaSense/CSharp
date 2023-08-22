using Microsoft.AspNetCore.Mvc;

namespace WebAppEmpty_ActionResult.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()    
        {
            return View();  //ViewResult, PartialViewResult, JsonResult etc...
        }
        public string Display()
        {
            return "Welcome Display Page";
        }
        public int DisplayId(int id)
        {
            return id;
        }
        public IActionResult Contact() 
        {
            ViewData["data1"] = "홍길동";
            ViewData["data2"] = 20;
            ViewData["data3"] = DateTime.Now.ToLongDateString();

            string[] fruits = { "사과", "배", "딸기" };
            ViewData["data4"] = fruits;

            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
