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
    [Route("Admin/Events")]
    public class AdminEventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var events = await _context.EventItems
                .OrderBy(item => item.EventDate)
                .ToListAsync();

            return View(events);
        }

        [HttpGet("Details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var eventItem = await _context.EventItems.FindAsync(id);
            if (eventItem == null)
            {
                return NotFound();
            }

            return View(eventItem);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(new EventItem());
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventItem eventItem)
        {
            if (!ModelState.IsValid)
            {
                return View(eventItem);
            }

            _context.EventItems.Add(eventItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var eventItem = await _context.EventItems.FindAsync(id);
            if (eventItem == null)
            {
                return NotFound();
            }

            return View(eventItem);
        }

        [HttpPost("Edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EventItem eventItem)
        {
            if (id != eventItem.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(eventItem);
            }

            _context.Update(eventItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eventItem = await _context.EventItems.FindAsync(id);
            if (eventItem == null)
            {
                return NotFound();
            }

            return View(eventItem);
        }

        [HttpPost("Delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventItem = await _context.EventItems.FindAsync(id);
            if (eventItem != null)
            {
                _context.EventItems.Remove(eventItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
