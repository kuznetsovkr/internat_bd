using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace internat_bd.Controllers
{
    [Authorize]
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
