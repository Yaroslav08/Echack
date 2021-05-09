using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.Authentication
{
    public class LoginModel
    {
        [Required, MinLength(8), MaxLength(100)]
        public string Login { get; set; }
        [Required, MinLength(8), MaxLength(35)]
        public string Password { get; set; }
    }
}