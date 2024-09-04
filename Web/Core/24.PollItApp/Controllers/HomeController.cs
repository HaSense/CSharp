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

			// Poll 데이터를 ID로 찾음
			var poll = context.Polls.Find(id);
			if (poll == null)
			{
				return NotFound();
			}

			// 뷰에 poll 객체를 전달
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
					// Poll 데이터를 업데이트
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

		// Poll이 존재하는지 확인하는 메서드
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

			// Poll 데이터를 ID로 찾음
			var poll = context.Polls.Find(id);
			if (poll == null)
			{
				return NotFound();
			}

			// 뷰에 poll 객체를 전달
			return View(poll);
		}
		public IActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			// Poll 데이터를 ID로 찾음
			var poll = context.Polls.Find(id);
			if (poll == null)
			{
				return NotFound();
			}

			// 뷰에 poll 객체를 전달
			return View(poll);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			// ID로 Poll 데이터 조회
			var poll = context.Polls.Find(id);

			if (poll == null)
			{
				return NotFound();
			}
			// Poll 데이터 삭제
			context.Polls.Remove(poll);
			context.SaveChanges();

			// 삭제 후 Index 페이지로 리다이렉트
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
