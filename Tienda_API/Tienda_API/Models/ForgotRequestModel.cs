using System.ComponentModel.DataAnnotations;

namespace Tienda_API.Models
{
    public class ForgotRequestModel
    {
        [Required]
        public string CorreoElectronico { get; set; } = string.Empty;
    }
}
