using Ereceipt.Application.ViewModels.Group;
namespace Ereceipt.Application.Results.Groups
{
    public class GroupResult : Result<GroupViewModel>
    {
        public GroupResult(GroupViewModel group) : base(group) { }
    }
}