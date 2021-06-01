using System;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.GroupMember
{
    public class GroupMemberRemoveModel : RequestModel
    {
        [Required(ErrorMessage = "GroupMemberID is required")]
        public Guid GroupMemberId { get; set; }
    }
}