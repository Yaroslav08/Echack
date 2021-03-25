using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.User
{
    public class UserEditViewModel : RequestModel
    {
        [Required, MinLength(5), MaxLength(150)]
        public string Name { get; set; }
    }
}