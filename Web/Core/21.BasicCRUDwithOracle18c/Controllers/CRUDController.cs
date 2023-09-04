using BasicCRUDwithOracle18cEx.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicCRUDwithOracle18cEx.Controllers
{
    public class CRUDController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentDbContext _context;
        public CRUDController(StudentDbContext context, ILogger<HomeController> logger) 
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student std)
        {
            if (ModelState.IsValid)
            {
                _context.Student.Add(std);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(std);
        }
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var stdData = _context.Student.FirstOrDefault(x => x.Id == id);

            if (stdData == null)
            {
                return NotFound();
            }

            return View(stdData);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var stdData =  _context.Student.Find(id);

            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }

        [HttpPost]
        public IActionResult Edit(int? id, Student std)
        {
            if (id != std.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(std);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(std);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }
            var stdData = _context.Student.FirstOrDefault((x => x.Id == id));

            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            var stdData = _context.Student.Find(id);
            if (stdData != null)
            {
                _context.Student.Remove(stdData);
            }
            _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
