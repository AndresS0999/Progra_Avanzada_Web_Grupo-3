using System.ComponentModel.DataAnnotations;

namespace AgataMakeUp_WEB.Models
{
    public class LoginRequestModel
    {
        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Contrasena { get; set; } = string.Empty;
    }
}
