using Microsoft.AspNetCore.Mvc;

namespace AgataMakeUp_WEB.Controllers
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
