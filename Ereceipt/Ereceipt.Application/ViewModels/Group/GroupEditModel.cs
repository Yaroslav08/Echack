using System;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.Group
{
    public class GroupEditModel : GroupCreateModel
    {
        [Required(ErrorMessage = "ID is required")]
        public Guid Id { get; set; }
    }
}