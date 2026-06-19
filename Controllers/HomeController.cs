using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using internat_bd.Data;
using internat_bd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace internat_bd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public async Task<IActionResult> News()
        {
            var news = await _context.NewsItems
                .OrderByDescending(item => item.PublishDate)
                .ToListAsync();

            return View(news);
        }

        public async Task<IActionResult> Staff()
        {
            var employees = await _context.Employees
                .OrderBy(employee => employee.Department)
                .ThenBy(employee => employee.FullName)
                .ToListAsync();

            return View(employees);
        }

        public async Task<IActionResult> Events()
        {
            var events = await _context.EventItems
                .OrderBy(item => item.EventDate)
                .ToListAsync();

            return View(events);
        }

        public IActionResult Appeal()
        {
            return View(new Appeal());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Appeal(Appeal model)
        {
            model.CreatedAt = DateTime.Now;
            model.Status = "Новое";
            ModelState.Remove("Status");

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _context.Appeals.Add(model);
            await _context.SaveChangesAsync();

            TempData["AppealMessage"] = "Обращение принято. Спасибо за ваше сообщение.";
            return RedirectToAction(nameof(Appeal));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
