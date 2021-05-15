using Ereceipt.Application.Results.Groups;
using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.GroupMember;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class RemoveUserFromGroupCommand : IRequest<GroupMemberResult>
    {
        public GroupMemberRemoveModel Member { get; }

        public RemoveUserFromGroupCommand(GroupMemberRemoveModel member)
        {
            Member = member;
        }
    }

    public class RemoveUserFromGroupCommandHandler : IRequestHandler<RemoveUserFromGroupCommand, GroupMemberResult>
    {
        private readonly IGroupService _groupService;
        public RemoveUserFromGroupCommandHandler(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public async Task<GroupMemberResult> Handle(RemoveUserFromGroupCommand request, CancellationToken cancellationToken)
        {
            return await _groupService.RemoveUserFromGroupAsync(request.Member);
        }
    }
}