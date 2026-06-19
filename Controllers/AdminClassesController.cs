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
    [Route("Admin/Classes")]
    public class AdminClassesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminClassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var classes = await _context.SchoolClasses
                .Include(schoolClass => schoolClass.Students)
                .OrderBy(schoolClass => schoolClass.Name)
                .ToListAsync();

            return View(classes);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(new SchoolClass());
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SchoolClass schoolClass)
        {
            if (!ModelState.IsValid)
            {
                return View(schoolClass);
            }

            _context.SchoolClasses.Add(schoolClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var schoolClass = await _context.SchoolClasses.FindAsync(id);
            if (schoolClass == null)
            {
                return NotFound();
            }

            return View(schoolClass);
        }

        [HttpPost("Edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SchoolClass schoolClass)
        {
            if (id != schoolClass.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(schoolClass);
            }

            _context.Update(schoolClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var schoolClass = await _context.SchoolClasses
                .Include(item => item.Students)
                .FirstOrDefaultAsync(item => item.Id == id);

            if (schoolClass == null)
            {
                return NotFound();
            }

            return View(schoolClass);
        }

        [HttpPost("Delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schoolClass = await _context.SchoolClasses.FindAsync(id);
            if (schoolClass != null)
            {
                _context.SchoolClasses.Remove(schoolClass);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
