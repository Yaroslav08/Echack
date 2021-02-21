using Ereceipt.Application.ViewModels.Chack;
using Ereceipt.Application.ViewModels.Comment;
using Ereceipt.Application.ViewModels.GroupMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.ViewModels.User
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Role { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<ChackViewModel> Chacks { get; set; }
        public List<GroupMemberViewModel> GroupMembers { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}