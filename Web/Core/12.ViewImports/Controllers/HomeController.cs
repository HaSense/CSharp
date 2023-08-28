using EmptyViewImports.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmptyViewImports.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Student> students = new List<Student>
            {
                new Student{ Id = 1, Name="홍길동", Hp="010-1111-1111"},
                new Student{ Id = 2, Name="이순신", Hp="010-2222-2222"},
                new Student{ Id = 3, Name="강감찬", Hp="010-3333-3333"},

            };
            return View(students);
        }
        public IActionResult About()
        {
            List<Student> students = new List<Student>
            {
                new Student{ Id = 1, Name="홍길동", Hp="010-1111-1111"},
                new Student{ Id = 2, Name="이순신", Hp="010-2222-2222"},
                new Student{ Id = 3, Name="강감찬", Hp="010-3333-3333"},

            };
            return View(students);
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
