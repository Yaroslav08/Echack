using Ereceipt.Application.ViewModels.GroupMember;
using System.Collections.Generic;

namespace Ereceipt.Application.Results.Groups
{
    public class ListGroupMemberResult : Result<List<GroupMemberViewModel>>
    {
        public ListGroupMemberResult(List<GroupMemberViewModel> members) : base(members) { }
    }
}
