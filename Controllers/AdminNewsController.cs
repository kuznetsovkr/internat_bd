using System.Linq;
using System.Threading.Tasks;
using internat_bd.Data;
using internat_bd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace internat_bd.Controllers
{
    [Authorize]
    [Route("Admin/News")]
    public class AdminNewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminNewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var news = await _context.NewsItems
                .OrderByDescending(item => item.PublishDate)
                .ToListAsync();

            return View(news);
        }

        [HttpGet("Details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var newsItem = await _context.NewsItems.FindAsync(id);
            if (newsItem == null)
            {
                return NotFound();
            }

            return View(newsItem);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(new NewsItem());
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewsItem newsItem)
        {
            if (!ModelState.IsValid)
            {
                return View(newsItem);
            }

            _context.NewsItems.Add(newsItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var newsItem = await _context.NewsItems.FindAsync(id);
            if (newsItem == null)
            {
                return NotFound();
            }

            return View(newsItem);
        }

        [HttpPost("Edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NewsItem newsItem)
        {
            if (id != newsItem.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(newsItem);
            }

            _context.Update(newsItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var newsItem = await _context.NewsItems.FindAsync(id);
            if (newsItem == null)
            {
                return NotFound();
            }

            return View(newsItem);
        }

        [HttpPost("Delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsItem = await _context.NewsItems.FindAsync(id);
            if (newsItem != null)
            {
                _context.NewsItems.Remove(newsItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
