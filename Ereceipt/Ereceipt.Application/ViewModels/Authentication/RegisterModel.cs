using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.Authentication
{
    public class RegisterModel
    {
        [Required, MinLength(5), MaxLength(150)]
        public string Name { get; set; }
        [MinLength(8), MaxLength(100)]
        public string Login { get; set; }
        [MinLength(8), MaxLength(25)]
        public string Password { get; set; }
        public string Photo { get; set; }
    }
}