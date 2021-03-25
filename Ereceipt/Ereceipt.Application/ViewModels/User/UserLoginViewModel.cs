using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.User
{
    public class UserLoginViewModel : RequestModel
    {
        [Required, MinLength(8), MaxLength(100)]
        public string Login { get; set; }
        [Required, MinLength(8), MaxLength(35)]
        public string Password { get; set; }
    }
}