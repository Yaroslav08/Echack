using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.Results.Groups;
using Ereceipt.Application.ViewModels.Group;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ereceipt.Application.MediatR.Commands
{
    public class EditGroupCommand : IRequest<GroupResult>
    {
        public GroupEditModel Group { get; }
        public EditGroupCommand(GroupEditModel group)
        {
            Group = group;
        }
    }

    public class GroupEditCommandHandler : IRequestHandler<EditGroupCommand, GroupResult>
    {
        IGroupService _groupService;
        public GroupEditCommandHandler(IGroupService groupService)
        {
            _groupService = groupService;
        }


        public async Task<GroupResult> Handle(EditGroupCommand request, CancellationToken cancellationToken)
        {
            if (await _groupService.CanEditGroupAsync(request.Group.Id, request.Group.UserId))
                return await _groupService.EditGroupAsync(request.Group);
            return null;
        }
    }
}
