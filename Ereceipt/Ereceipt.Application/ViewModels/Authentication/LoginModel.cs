using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Login is required")]
        [MinLength(8, ErrorMessage = "Min length of login is 8 symbols")]
        [MaxLength(100, ErrorMessage = "Max length of login is 100 symbols")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Min length of password is 8 symbols")]
        [MaxLength(35, ErrorMessage = "Max length of password is 35 symbols")]
        public string Password { get; set; }
    }
}