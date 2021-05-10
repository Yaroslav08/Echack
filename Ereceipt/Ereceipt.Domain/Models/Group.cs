using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Domain.Models
{
    public class Group : BaseModel<Guid>
    {
        [Required, MinLength(1), MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Color { get; set; } = "#6495ED";
        [MinLength(10), MaxLength(250)]
        public string Desc { get; set; }
        public List<GroupMember> GroupMembers { get; set; }
        public List<Receipt> Receipts { get; set; }
        public List<Budget> Budgets { get; set; }
    }
}