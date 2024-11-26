using Microsoft.AspNetCore.Mvc;
using MVCLogin.Models;
using System.Diagnostics;

namespace MVCLogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        //Login����� ���� �߰�
        private readonly LoginDbContext context;

        //context�� �����ϱ� ���� ���ڸ� 1�� �� �ø��� ����� ����
        public HomeController(ILogger<HomeController> logger, LoginDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        //�⺻ ����������
        public IActionResult Index()
        {
            //���ǰ��� �ִٸ�
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                //������ ������ ViewBag�� ����ϴ�.
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                //���ǰ��� ���� ���� ���� ���� �����ؼ� �ڵ� �մϴ�.                
            }

            return View();
        }
        //Login�� ���� get ������ 
        public IActionResult Login()
        {

            //���ǰ��� �ִٸ�
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                //������ ������ ViewBag�� ����ϴ�.
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }

            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginUser user)
        {
            //SqlServer�� �ִ� Id/password�� ������ �Է��� id/password�� ���մϴ�.
            var myUser = context.LoginUsers.Where(
                x => x.UserId == user.UserId &&
                     x.UserPwd == user.UserPwd)
                .FirstOrDefault();

            if (myUser != null)
            {
                //������ ����� �ڵ� �Դϴ�.
                //������ ������ [Key, Value] �������� ����ϴ�. Key�� UserSession�̶� �ܾ� Value�� DB�� �ִ� email ���Դϴ�.
                HttpContext.Session.SetString("UserSession", myUser.UserId.ToString());

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "�α��� ����";

                return RedirectToAction("SignUp");
            }
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                //���������� �����մϴ�.
                HttpContext.Session.Remove("UserSession");
                //return RedirectToAction("Login", "Home");  //�α׾ƿ� �� �ٷ� �α��� ȭ������ �̵�
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
                //�������̶�� DB�� ����ڸ� �߰��ϰ� 
                context.LoginUsers.Add(user);
                //DB�� �����Ѵ�.
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
