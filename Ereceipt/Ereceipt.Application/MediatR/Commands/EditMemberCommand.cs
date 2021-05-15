using Ereceipt.Application.Results.Groups;
using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.GroupMember;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ereceipt.Application.MediatR.Commands
{
    public class EditMemberCommand : IRequest<GroupMemberResult>
    {
        public GroupMemberEditModel GroupMember { get; set; }

        public EditMemberCommand(GroupMemberEditModel groupMember)
        {
            GroupMember = groupMember;
        }
    }

    public class EditMemberCommandHandler : IRequestHandler<EditMemberCommand, GroupMemberResult>
    {
        private readonly IGroupService _groupService;
        public EditMemberCommandHandler(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public async Task<GroupMemberResult> Handle(EditMemberCommand request, CancellationToken cancellationToken)
        {
            return await _groupService.EditPermissionsInUserAsync(request.GroupMember);
        }
    }
}