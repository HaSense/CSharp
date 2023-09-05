using LoginFormEasy.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoginFormEasy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SmartFactoryDbContext _context;

        public HomeController(ILogger<HomeController> logger, SmartFactoryDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Login()
        {
            //넘어온 세션의 값이 null일 경우 Login페이지로 바로 가기
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                //세션의 내용을 ViewBag에 담습니다.
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            //SqlServer에 있는 Id/password와 폼에서 입력한 id/password를 비교합니다.
            var myUser = _context.User.Where(
                x => x.AccountId == user.AccountId &&
                     x.AccountPassword == user.AccountPassword)
                .FirstOrDefault();

            if (myUser != null)
            {
                //세션을 만드는 코드 입니다.
                //세션의 정보를 [Key, Value] 조합으로 만듭니다. Key는 UserSession이란 단어 Value는 DB에 있는 email 값입니다.
                HttpContext.Session.SetString("UserSession", myUser.AccountId);

                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Message = "로그인 실패";
            }

            return View();
        }
        public IActionResult DashBoard()
        {
            //넘어온 세션의 값이 null이 아닐 경우 즉, 로그인 작업으로 세션이 만들어져 있는 경우
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                //세션의 내용을 ViewBag에 담습니다.
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }


        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                //세션정보를 삭제합니다.
                HttpContext.Session.Remove("UserSession");
                //return RedirectToAction("Login", "Home");  //로그아웃 후 바로 로그인 화면으로 이동
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