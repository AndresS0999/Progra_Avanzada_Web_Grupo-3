using Microsoft.AspNetCore.Mvc;

namespace AgataMakeUp_WEB.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("NombreRol") == null)
                return RedirectToAction("Login", "Cuenta");

            if (HttpContext.Session.GetString("NombreRol") != "ADMIN")
                return RedirectToAction("Index", "Home");

            return View();
        }
    }
}
