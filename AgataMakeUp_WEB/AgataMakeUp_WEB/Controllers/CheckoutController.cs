
using Microsoft.AspNetCore.Mvc;

namespace AgataMakeUp_WEB.Controllers
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
