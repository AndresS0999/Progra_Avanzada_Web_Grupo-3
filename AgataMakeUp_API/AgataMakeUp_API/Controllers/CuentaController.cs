using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using AgataMakeUp_API.Models;

namespace AgataMakeUp_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentaController(IConfiguration _configuration) : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginRequestModel model)
        {
            using var context = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection"));

            var parametros = new DynamicParameters();
            parametros.Add("@Correo", model.Correo);
            parametros.Add("@Contrasena", model.Contrasena);

            var response = context.QueryFirstOrDefault<UsuarioResponse>("sp_IniciarSesionUsuario", parametros);

            if (response == null)
                return NotFound("El correo electrónico o la contraseña son incorrectos.");

            return Ok(response);
        }
    }
}
