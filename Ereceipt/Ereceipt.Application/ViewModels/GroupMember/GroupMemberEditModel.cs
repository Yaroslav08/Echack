using System;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.GroupMember
{
    public class GroupMemberEditModel : RequestModel
    {
        [Required(ErrorMessage = "ID is required")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "CanEditGroup is required")]
        public bool CanEditGroup { get; set; }
        [Required(ErrorMessage = "CanAddMember is required")]
        public bool CanAddMember { get; set; }
        [Required(ErrorMessage = "CanRemoveMember is required")]
        public bool CanRemoveMember { get; set; }
        [Required(ErrorMessage = "CanControlBudget is required")]
        public bool CanControlBudget { get; set; }
        [Required(ErrorMessage = "CanRemoveReceipt is required")]
        public bool CanRemoveReceipt { get; set; }
    }
}