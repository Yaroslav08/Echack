using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.Authentication
{
    public class RegisterModel : LoginModel
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Min length of name is 2 symbols")]
        [MaxLength(150, ErrorMessage = "Max length of name is 150 symbols")]
        public string Name { get; set; }
        public string Photo { get; set; }
    }
}