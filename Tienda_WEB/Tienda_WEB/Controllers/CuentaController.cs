using Microsoft.AspNetCore.Mvc;
using System.Net;
using Tienda_WEB.Models;

namespace Tienda_WEB.Controllers
{
    public class CuentaController(HttpClient _httpClient, IConfiguration _configuration) : Controller
    {
        #region Inicio de Sesión

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginRequestModel model)
        {
            using var client = _httpClient;
            var url = _configuration.GetValue<string>("Variables:ApiBaseUrl") + "Cuenta/Login";

            var response = client.PostAsJsonAsync(url, model).Result;

            if(response.StatusCode == HttpStatusCode.OK)
                return RedirectToAction("Index", "Home");

            ViewBag.Mensaje = response.Content.ReadAsStringAsync().Result;
            return View();
        }

        #endregion

        #region Registro de Usuarios

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registro(RegisterRequestModel model)
        {
            using var client = _httpClient;
            var url = _configuration.GetValue<string>("Variables:ApiBaseUrl") + "Cuenta/Registro";

            var response = client.PostAsJsonAsync(url, model).Result;

            if (response.StatusCode == HttpStatusCode.OK)
                return RedirectToAction("Login", "Cuenta");

            ViewBag.Mensaje = response.Content.ReadAsStringAsync().Result;
            return View();
        }

        #endregion

        #region Recuperar la Contraseña

        [HttpGet]
        public IActionResult Recuperar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Recuperar(ForgotRequestModel model)
        {
            using var client = _httpClient;
            var url = _configuration.GetValue<string>("Variables:ApiBaseUrl") + "Cuenta/Recuperar";

            var response = client.PostAsJsonAsync(url, model).Result;

            //Validar response

            return View();
        }

        #endregion
    }
}
