using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Results.Groups;
using Ereceipt.Application.ViewModels.Group;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class GroupCreateCommand : IRequest<GroupResult>
    {
        public GroupCreateViewModel Group { get; set; }
        public GroupCreateCommand(GroupCreateViewModel group)
        {
            Group = group;
        }
    }

    public class GroupCreateCommandHandler : IRequestHandler<GroupCreateCommand, GroupResult>
    {
        IGroupService _groupService;

        public GroupCreateCommandHandler(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public async Task<GroupResult> Handle(GroupCreateCommand request, CancellationToken cancellationToken)
        {
            return await _groupService.CreateGroup(request.Group);
        }
    }
}