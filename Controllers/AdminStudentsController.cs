using System.Linq;
using System.Threading.Tasks;
using internat_bd.Data;
using internat_bd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace internat_bd.Controllers
{
    [Authorize]
    [Route("Admin/Students")]
    public class AdminStudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminStudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var students = await _context.Students
                .Include(student => student.SchoolClass)
                .OrderBy(student => student.SchoolClass.Name)
                .ThenBy(student => student.FullName)
                .ToListAsync();

            return View(students);
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            await FillClassesList();
            return View(new Student());
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            ModelState.Remove(nameof(Student.SchoolClass));

            if (!ModelState.IsValid)
            {
                await FillClassesList(student.SchoolClassId);
                return View(student);
            }

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            await FillClassesList(student.SchoolClassId);
            return View(student);
        }

        [HttpPost("Edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            ModelState.Remove(nameof(Student.SchoolClass));

            if (!ModelState.IsValid)
            {
                await FillClassesList(student.SchoolClassId);
                return View(student);
            }

            _context.Update(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students
                .Include(item => item.SchoolClass)
                .FirstOrDefaultAsync(item => item.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost("Delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task FillClassesList(int? selectedClassId = null)
        {
            var classes = await _context.SchoolClasses
                .OrderBy(schoolClass => schoolClass.Name)
                .ToListAsync();

            ViewBag.SchoolClassId = new SelectList(classes, "Id", "Name", selectedClassId);
        }
    }
}
