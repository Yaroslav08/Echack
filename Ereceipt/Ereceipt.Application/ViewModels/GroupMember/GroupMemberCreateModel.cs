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
    }
}