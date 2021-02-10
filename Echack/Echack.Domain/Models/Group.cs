using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Echack.Domain.Models
{
    public class Group : BaseModelWithIdentityGen<Guid>
    {
        [Required, MinLength(1), MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Color { get; set; } = "#6495ED";
        [MinLength(10), MaxLength(250)]
        public string Desc { get; set; }
        public List<GroupMember> GroupMembers { get; set; }
    }
}