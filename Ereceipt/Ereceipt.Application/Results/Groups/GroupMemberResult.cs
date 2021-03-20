using Ereceipt.Application.ViewModels.GroupMember;
using Ereceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereceipt.Application.Results.Groups
{
    public class GroupMemberResult : Result<GroupMemberViewModel>
    {
        public GroupMemberResult(GroupMemberViewModel groupMember) : base(groupMember) { }
    }
}
