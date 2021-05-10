using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.Results.Groups;
using Ereceipt.Application.ViewModels.Group;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class CreateGroupCommand : IRequest<GroupResult>
    {
        public GroupCreateModel Group { get; set; }
        public CreateGroupCommand(GroupCreateModel group)
        {
            Group = group;
        }
    }

    public class GroupCreateCommandHandler : IRequestHandler<CreateGroupCommand, GroupResult>
    {
        private readonly IGroupService _groupService;

        public GroupCreateCommandHandler(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public async Task<GroupResult> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            return await _groupService.CreateGroupAsync(request.Group);
        }
    }
}