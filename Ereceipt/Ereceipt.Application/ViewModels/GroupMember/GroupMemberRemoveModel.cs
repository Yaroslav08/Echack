using System;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.GroupMember
{
    public class GroupMemberRemoveModel : RequestModel
    {
        [Required]
        public Guid GroupMemberId { get; set; }
    }
}