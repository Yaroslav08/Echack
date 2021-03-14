using Ereceipt.Application.ViewModels.Group;
using Ereceipt.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.ViewModels.GroupMember
{
    public class GroupMemberCreateViewModel : RequestModel
    {
        [Required]
        public Guid GroupId { get; set; }
        [Required]
        public int Id { get; set; }
    }
}