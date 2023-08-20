using Microsoft.AspNetCore.Mvc;

namespace RoutingWithoutMVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult First()
        {
            return View();
        }
    }
}
