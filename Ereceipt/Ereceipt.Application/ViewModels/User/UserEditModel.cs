using System;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.User
{
    public class UserEditModel : RequestModel
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Min length of name is 2 symbols")]
        [MaxLength(150, ErrorMessage = "Max length of name is 250 symbols")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [MinLength(3, ErrorMessage = "Min length of username is 3 symbols")]
        [MaxLength(30, ErrorMessage = "Max length of username is 30 symbols")]
        public string Username { get; set; }
    }
}