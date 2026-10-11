using Microsoft.AspNetCore.Mvc;

namespace Tienda_WEB.Controllers
{
    public class CheckoutController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
