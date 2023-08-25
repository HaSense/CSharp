using Microsoft.AspNetCore.Mvc;
using StronglyTypedViewTest1.Models;
using System.Diagnostics;

namespace StronglyTypedViewTest1.Controllers
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
            //Employee obj = new Employee()
            //{
            //    EmpId = 100,
            //    EmpName = "홍길동",
            //    Designation = "대리",
            //    Salary = 25000
            //};
            //return View(obj);

            var myEmployees = new List<Employee>
            {
                new Employee { EmpId=101, EmpName="홍길동", Designation="대리", Salary=35000},
                new Employee { EmpId=101, EmpName="이순신", Designation="부장", Salary=60000},
                new Employee { EmpId=101, EmpName="강감찬", Designation="상무", Salary=70000},
            };
            //TempData["myEmployee"] = myEmployees;
            
            return View(myEmployees);
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
