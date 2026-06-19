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
    [Route("Admin/Documents")]
    public class AdminDocumentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminDocumentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var documents = await _context.DocumentItems
                .OrderByDescending(item => item.UploadDate)
                .ToListAsync();

            return View(documents);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(new DocumentItem());
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DocumentItem documentItem)
        {
            if (!ModelState.IsValid)
            {
                return View(documentItem);
            }

            _context.DocumentItems.Add(documentItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var documentItem = await _context.DocumentItems.FindAsync(id);
            if (documentItem == null)
            {
                return NotFound();
            }

            return View(documentItem);
        }

        [HttpPost("Edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DocumentItem documentItem)
        {
            if (id != documentItem.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(documentItem);
            }

            _context.Update(documentItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var documentItem = await _context.DocumentItems.FindAsync(id);
            if (documentItem == null)
            {
                return NotFound();
            }

            return View(documentItem);
        }

        [HttpPost("Delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var documentItem = await _context.DocumentItems.FindAsync(id);
            if (documentItem != null)
            {
                _context.DocumentItems.Remove(documentItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
