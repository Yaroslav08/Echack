using System;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.GroupMember
{
    public class GroupMemberEditModel : RequestModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public bool CanEditGroup { get; set; }
        [Required]
        public bool CanAddMember { get; set; }
        [Required]
        public bool CanRemoveMember { get; set; }
        [Required]
        public bool CanControlBudget { get; set; }
        [Required]
        public bool CanRemoveReceipt { get; set; }
    }
}