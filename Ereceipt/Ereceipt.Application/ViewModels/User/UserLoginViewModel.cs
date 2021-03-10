using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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