using System.Diagnostics;
using internat_bd.Data;
using internat_bd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace internat_bd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
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

        public IActionResult News()
        {
            return View(StaticSchoolData.News);
        }

        public IActionResult Staff()
        {
            return View(StaticSchoolData.Staff);
        }

        public IActionResult Events()
        {
            return View(StaticSchoolData.Events);
        }

        public IActionResult Appeal()
        {
            return View(new AppealViewModel());
        }

        [HttpPost]
        public IActionResult Appeal(AppealViewModel model)
        {
            TempData["AppealMessage"] = "Обращение принято в учебном режиме. Данные пока не сохраняются в базе.";
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
