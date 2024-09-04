using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PollItApp.Models;
using System.Diagnostics;

namespace PollItApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly PollDbContext context;

        public HomeController(PollDbContext _context, ILogger<HomeController> _logger)
        {
            logger = _logger;
            context = _context;
        }

        public IActionResult Index()
        {
            var polls = context.Polls.ToList<Poll>();
            return View(polls);
        }
		public IActionResult Create()
		{
			return View();
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Q1, Q2, Q10")] Poll poll)
        {
            if (ModelState.IsValid)
            {
                context.Add(poll);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(poll);
        }

		public IActionResult Edit(int? id)
        {
			if (id == null)
			{
				return NotFound();
			}

			// Poll �����͸� ID�� ã��
			var poll = context.Polls.Find(id);
			if (poll == null)
			{
				return NotFound();
			}

			// �信 poll ��ü�� ����
			return View(poll);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, [Bind("Id,Q1,Q2,Q10")] Poll poll)
		{
			if (id != poll.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					// Poll �����͸� ������Ʈ
					context.Update(poll);
					context.SaveChanges();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!PollExists(poll.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(poll);
		}

		// Poll�� �����ϴ��� Ȯ���ϴ� �޼���
		private bool PollExists(int id)
		{
			return context.Polls.Any(e => e.Id == id);
		}

		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			// Poll �����͸� ID�� ã��
			var poll = context.Polls.Find(id);
			if (poll == null)
			{
				return NotFound();
			}

			// �信 poll ��ü�� ����
			return View(poll);
		}
		public IActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			// Poll �����͸� ID�� ã��
			var poll = context.Polls.Find(id);
			if (poll == null)
			{
				return NotFound();
			}

			// �信 poll ��ü�� ����
			return View(poll);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			// ID�� Poll ������ ��ȸ
			var poll = context.Polls.Find(id);

			if (poll == null)
			{
				return NotFound();
			}
			// Poll ������ ����
			context.Polls.Remove(poll);
			context.SaveChanges();

			// ���� �� Index �������� �����̷�Ʈ
			return RedirectToAction(nameof(Index));
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
