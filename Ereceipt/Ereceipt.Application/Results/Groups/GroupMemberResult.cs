using Ereceipt.Application.ViewModels.GroupMember;

namespace Ereceipt.Application.Results.Groups
{
    public class GroupMemberResult : Result<GroupMemberViewModel>
    {
        public GroupMemberResult(GroupMemberViewModel groupMember) : base(groupMember) { }
    }
}
