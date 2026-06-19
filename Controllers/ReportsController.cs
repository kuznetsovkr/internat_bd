using System.Linq;
using System.Threading.Tasks;
using internat_bd.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace internat_bd.Controllers
{
    [Authorize]
    [Route("Reports")]
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("StudentsByClass")]
        public async Task<IActionResult> StudentsByClass()
        {
            var students = await _context.Students
                .Include(student => student.SchoolClass)
                .OrderBy(student => student.SchoolClass.Name)
                .ThenBy(student => student.FullName)
                .ToListAsync();

            return View(students);
        }
    }
}
