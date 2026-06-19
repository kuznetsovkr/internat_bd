using Microsoft.AspNetCore.Mvc;

namespace internat_bd.Controllers
{
    [Route("Admin")]
    public class AdminController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
