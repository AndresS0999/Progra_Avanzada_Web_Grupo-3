using System;
using System.Web;
using System.Web.Mvc;

namespace Tienda.Controllers
{
    public class IdiomaController : Controller
    {
        // Guarda el idioma elegido en una cookie y regresa a la página donde estaba el usuario.
        public ActionResult Cambiar(string codigo, string returnUrl)
        {
            var idioma = MvcApplication.NormalizarIdioma(codigo);

            Response.Cookies.Add(new HttpCookie(MvcApplication.CookieIdioma, idioma)
            {
                Expires = DateTime.Now.AddYears(1),
                HttpOnly = true
            });

            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
