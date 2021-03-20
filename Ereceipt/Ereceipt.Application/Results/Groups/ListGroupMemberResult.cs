using Ereceipt.Application.ViewModels.GroupMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereceipt.Application.Results.Groups
{
    public class ListGroupMemberResult : Result<List<GroupMemberViewModel>>
    {
        public ListGroupMemberResult(List<GroupMemberViewModel> members) : base(members) { }
    }
}
