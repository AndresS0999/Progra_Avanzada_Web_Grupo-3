using System.ComponentModel.DataAnnotations;

namespace AgataMakeUp_API.Models
{
    public class LoginRequestModel
    {
        [Required]
        public string Correo { get; set; } = string.Empty;
        [Required]
        public string Contrasena { get; set; } = string.Empty;
    }
}
