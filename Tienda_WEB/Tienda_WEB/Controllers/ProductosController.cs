using Microsoft.AspNetCore.Mvc;

namespace Tienda_WEB.Controllers
{
    public class ProductosController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Detalle()
        {
            return View();
        }
    }
}
