using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.Results.Groups;
using Ereceipt.Application.ViewModels.Group;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class GroupCreateCommand : IRequest<GroupResult>
    {
        public GroupCreateModel Group { get; set; }
        public GroupCreateCommand(GroupCreateModel group)
        {
            Group = group;
        }
    }

    public class GroupCreateCommandHandler : IRequestHandler<GroupCreateCommand, GroupResult>
    {
        private readonly IGroupService _groupService;

        public GroupCreateCommandHandler(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public async Task<GroupResult> Handle(GroupCreateCommand request, CancellationToken cancellationToken)
        {
            return await _groupService.CreateGroupAsync(request.Group);
        }
    }
}