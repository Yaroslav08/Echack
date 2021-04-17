using System;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Domain.Models
{
    public class GroupMember : BaseModelWithIdentityGen<Guid>
    {
        [Required, MinLength(1), MaxLength(100)]
        public string Title { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}