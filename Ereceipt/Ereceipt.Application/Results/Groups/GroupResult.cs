using Ereceipt.Application.ViewModels.Group;
namespace Ereceipt.Application.Results.Groups
{
    public class GroupResult : Result
    {
        public GroupResult(GroupViewModel group) : base(group) { }
        public GroupResult(string error) : base(error) { }
    }
}