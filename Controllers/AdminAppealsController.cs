using System.Linq;
using System.Threading.Tasks;
using internat_bd.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace internat_bd.Controllers
{
    [Route("Admin/Appeals")]
    public class AdminAppealsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminAppealsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var appeals = await _context.Appeals
                .OrderByDescending(appeal => appeal.CreatedAt)
                .ToListAsync();

            return View(appeals);
        }

        [HttpGet("Details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var appeal = await _context.Appeals.FindAsync(id);
            if (appeal == null)
            {
                return NotFound();
            }

            return View(appeal);
        }

        [HttpGet("EditStatus/{id:int}")]
        public async Task<IActionResult> EditStatus(int id)
        {
            var appeal = await _context.Appeals.FindAsync(id);
            if (appeal == null)
            {
                return NotFound();
            }

            return View(appeal);
        }

        [HttpPost("EditStatus/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditStatus(int id, string status)
        {
            var appeal = await _context.Appeals.FindAsync(id);
            if (appeal == null)
            {
                return NotFound();
            }

            if (string.IsNullOrWhiteSpace(status))
            {
                ModelState.AddModelError("Status", "Укажите статус обращения.");
                return View(appeal);
            }

            appeal.Status = status;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var appeal = await _context.Appeals.FindAsync(id);
            if (appeal == null)
            {
                return NotFound();
            }

            return View(appeal);
        }

        [HttpPost("Delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appeal = await _context.Appeals.FindAsync(id);
            if (appeal != null)
            {
                _context.Appeals.Remove(appeal);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
