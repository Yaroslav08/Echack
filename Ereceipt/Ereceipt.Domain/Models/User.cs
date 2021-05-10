using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Domain.Models
{
    public class User : BaseModel<int>
    {
        [Required, MinLength(5), MaxLength(150)]
        public string Name { get; set; }
        [Required, MinLength(3), MaxLength(30)]
        public string Username { get; set; }
        [MinLength(20), MaxLength(150)]
        public string Avatar { get; set; }
        [MinLength(8), MaxLength(100)]
        public string Login { get; set; }
        [MinLength(8), MaxLength(2500)]
        public string PasswordHash { get; set; }
        [Required, MaxLength(50)]
        public string Role { get; set; }
        public List<Receipt> Receipts { get; set; }
        public List<GroupMember> GroupMembers { get; set; }
        public List<Comment> Comments { get; set; }
    }
}