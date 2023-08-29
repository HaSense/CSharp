using CRUDMVC01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CRUDMVC01.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly StudentDbContext _context;
        public HomeController(StudentDbContext context) 
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Student.ToList();
            return View(students);
        }

        // GET: 삽입화면
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: 삽입기능
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Hp")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        //삭제
        [HttpPost]
        public async Task<IActionResult> DeleteSelected(List<int> selectedStudents)
        {
            var studentsToDelete = _context.Student.Where(s => selectedStudents.Contains(s.Id)).ToList();

            _context.Student.RemoveRange(studentsToDelete);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }
        public IActionResult Update(Student std)
        {
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