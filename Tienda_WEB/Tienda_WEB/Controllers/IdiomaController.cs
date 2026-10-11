using Microsoft.AspNetCore.Mvc;

namespace Tienda_WEB.Controllers
{
    public class IdiomaController : Controller
    {
        public const string CookieIdioma = "idioma";

        // Solo se admiten español ("es", por defecto) e inglés ("en").
        public static string NormalizarIdioma(string? codigo)
        {
            return codigo == "en" ? "en" : "es";
        }

        // Guarda el idioma elegido en una cookie y regresa a la página donde estaba el usuario.
        [HttpGet]
        public IActionResult Cambiar(string codigo, string returnUrl)
        {
            var idioma = NormalizarIdioma(codigo);

            Response.Cookies.Append(CookieIdioma, idioma, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddYears(1),
                HttpOnly = true
            });

            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }
    }
}
