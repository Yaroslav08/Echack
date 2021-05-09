using Ereceipt.Application.Results.Groups;
using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.GroupMember;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class AddUserToGroupCommand : IRequest<GroupMemberResult>
    {
        public GroupMemberCreateViewModel GroupData { get; }
        public AddUserToGroupCommand(GroupMemberCreateViewModel groupData)
        {
            GroupData = groupData;
        }
    }

    public class AddUserToGroupCommandHandler : IRequestHandler<AddUserToGroupCommand, GroupMemberResult>
    {
        private readonly IGroupService _groupService;
        public AddUserToGroupCommandHandler(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public async Task<GroupMemberResult> Handle(AddUserToGroupCommand request, CancellationToken cancellationToken)
        {
            return await _groupService.AddUserToGroupAsync(request.GroupData);
        }
    }
}