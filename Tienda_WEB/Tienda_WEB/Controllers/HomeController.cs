using Microsoft.AspNetCore.Mvc;

namespace Tienda_WEB.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
