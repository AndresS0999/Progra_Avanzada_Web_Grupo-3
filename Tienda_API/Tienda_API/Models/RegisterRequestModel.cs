using System.ComponentModel.DataAnnotations;

namespace Tienda_API.Models
{
    public class RegisterRequestModel
    {
        [Required]
        public string CorreoElectronico { get; set; } = string.Empty;
        [Required]
        public string Contrasenna { get; set; } = string.Empty;
    }
}
