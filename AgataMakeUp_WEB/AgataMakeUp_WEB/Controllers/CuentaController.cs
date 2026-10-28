using AgataMakeUp_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AgataMakeUp_WEB.Controllers
{
    public class CuentaController(HttpClient _httpClient, IConfiguration _configuration) : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginRequestModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using var client = _httpClient;
            var url = _configuration.GetValue<string>("Variables:ApiBaseUrl") + "Cuenta/Login";

            var response = client.PostAsJsonAsync(url, model).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var usuario = response.Content.ReadFromJsonAsync<UsuarioResponse>().Result!;

                HttpContext.Session.SetInt32("IdUsuario", usuario.IdUsuario);
                HttpContext.Session.SetString("NombreUsuario", usuario.Nombre + " " + usuario.Apellido);
                HttpContext.Session.SetString("NombreRol", usuario.NombreRol);

                if (usuario.NombreRol == "ADMIN")
                    return RedirectToAction("Index", "Admin");

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Mensaje = response.Content.ReadAsStringAsync().Result;
            return View(model);
        }

        [HttpGet]
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Recuperar()
        {
            return View();
        }
    }
}
