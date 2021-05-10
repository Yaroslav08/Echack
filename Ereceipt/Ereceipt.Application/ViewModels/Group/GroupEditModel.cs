using System;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.Group
{
    public class GroupEditModel : RequestModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required, MinLength(1), MaxLength(100)]
        public string Name { get; set; }
        [MinLength(2), MaxLength(25)]
        public string Color { get; set; }
        [MinLength(10), MaxLength(250)]
        public string Desc { get; set; }
    }
}