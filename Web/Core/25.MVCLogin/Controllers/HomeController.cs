using Microsoft.AspNetCore.Mvc;
using MVCLogin.Models;
using System.Diagnostics;

namespace MVCLogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        //Login기능을 위해 추가
        private readonly LoginDbContext context;

        //context를 제어하기 위해 인자를 1개 더 늘리고 멤버랑 연결
        public HomeController(ILogger<HomeController> logger, LoginDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        //기본 메인페이지
        public IActionResult Index()
        {
            //세션값이 있다면
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                //세션의 내용을 ViewBag에 담습니다.
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                //세션값이 있을 때와 없을 때는 구분해서 코딩 합니다.                
            }

            return View();
        }
        //Login을 위한 get 페이지 
        public IActionResult Login()
        {

            //세션값이 있다면
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                //세션의 내용을 ViewBag에 담습니다.
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }

            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginUser user)
        {
            //SqlServer에 있는 Id/password와 폼에서 입력한 id/password를 비교합니다.
            var myUser = context.LoginUsers.Where(
                x => x.UserId == user.UserId &&
                     x.UserPwd == user.UserPwd)
                .FirstOrDefault();

            if (myUser != null)
            {
                //세션을 만드는 코드 입니다.
                //세션의 정보를 [Key, Value] 조합으로 만듭니다. Key는 UserSession이란 단어 Value는 DB에 있는 email 값입니다.
                HttpContext.Session.SetString("UserSession", myUser.UserId.ToString());

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "로그인 실패";

                return RedirectToAction("SignUp");
            }
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                //세션정보를 삭제합니다.
                HttpContext.Session.Remove("UserSession");
                //return RedirectToAction("Login", "Home");  //로그아웃 후 바로 로그인 화면으로 이동
            }
            return RedirectToAction("Index");
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(LoginUser user)
        {
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine($"Error: {error.ErrorMessage}");
                    }
                }
            }
            else
            {
                //정상적이라면 DB에 사용자를 추가하고 
                context.LoginUsers.Add(user);
                //DB에 저장한다.
                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(user);
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
