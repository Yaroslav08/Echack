using Ereceipt.Application.ViewModels.GroupMember;

namespace Ereceipt.Application.Results.Groups
{
    public class GroupMemberResult : Result
    {
        public GroupMemberResult(GroupMemberViewModel groupMember) : base(groupMember) { }
        public GroupMemberResult(string error) : base(error) { }
    }
}
