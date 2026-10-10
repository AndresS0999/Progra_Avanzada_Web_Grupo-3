using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Tienda
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public const string CookieIdioma = "idioma";

        // Solo se admiten español ("es", por defecto) e inglés ("en").
        public static string NormalizarIdioma(string codigo)
        {
            return codigo == "en" ? "en" : "es";
        }

        // Aplica a cada petición el idioma guardado en la cookie, para que
        // Recursos\Textos devuelva los textos en ese idioma.
        protected void Application_BeginRequest()
        {
            var cookie = Request.Cookies[CookieIdioma];
            var idioma = NormalizarIdioma(cookie != null ? cookie.Value : null);

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(idioma);
        }
    }
}
