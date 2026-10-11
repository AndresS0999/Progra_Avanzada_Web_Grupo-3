using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Tienda_API.Models;

namespace Tienda_API.Controllers
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
            parametros.Add("@CorreoElectronico", model.CorreoElectronico);
            parametros.Add("@Contrasenna", model.Contrasenna);

            var response = context.QueryFirstOrDefault<UsuarioResponse>("sp_IniciarSesionUsuario", parametros);

            if(response == null)
                return NotFound("No se validó la información correctamente");

            return Ok(response);
        }

        [HttpPost]
        [Route("Registro")]
        public IActionResult Registro(RegisterRequestModel model)
        {
            using var context = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection"));

            var parametros = new DynamicParameters();
            parametros.Add("@CorreoElectronico", model.CorreoElectronico);
            parametros.Add("@Contrasenna", model.Contrasenna);

            var response = context.Execute("sp_RegistroUsuarios", parametros);

            if(response <= 0)
                return UnprocessableEntity("No se registró la información correctamente");

            return Ok("Se registró la información correctamente");
        }

        [HttpPost]
        [Route("Recuperar")]
        public IActionResult Recuperar(ForgotRequestModel model)
        {
            using var context = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection"));

            var parametros = new DynamicParameters();
            parametros.Add("@CorreoElectronico", model.CorreoElectronico);

            var response = context.Query("SP", parametros);

            return Ok(model);
        }

    }
}
