using System;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.GroupMember
{
    public class GroupMemberCreateModel : RequestModel
    {
        [Required]
        public Guid GroupId { get; set; }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public bool IsCreator { get; set; }
        public bool CanEditGroup { get; set; }
        public bool CanAddMember { get; set; }
        public bool CanRemoveMember { get; set; }
        public bool CanControlBudget { get; set; }
        public bool CanRemoveReceipt { get; set; }
    }
}