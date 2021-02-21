using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.ViewModels.User
{
    public class UserEditViewModel : RequestModel
    {
        [Required, MinLength(5), MaxLength(150)]
        public string Name { get; set; }
    }
}