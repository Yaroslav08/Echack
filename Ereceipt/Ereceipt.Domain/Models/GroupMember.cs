using System;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Domain.Models
{
    public class GroupMember : BaseModel<Guid>
    {
        [Required, MinLength(1), MaxLength(100)]
        public string Title { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public bool IsCreator { get; set; }
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