using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.ViewModels.GroupMember
{
    public class GroupMemberEditModel : RequestModel
    {
        [Required]
        public Guid Id { get; set; }
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