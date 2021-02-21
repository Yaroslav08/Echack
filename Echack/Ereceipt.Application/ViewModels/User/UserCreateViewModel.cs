using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.ViewModels.User
{
    public class UserCreateViewModel : RequestModel
    {
        [Required, MinLength(5), MaxLength(150)]
        public string Name { get; set; }
        [MinLength(8), MaxLength(100)]
        public string Login { get; set; }
        [MinLength(8), MaxLength(25)]
        public string Password { get; set; }
    }
}