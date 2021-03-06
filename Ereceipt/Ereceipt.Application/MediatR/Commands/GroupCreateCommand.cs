using Ereceipt.Application.Interfaces;
using Ereceipt.Application.ViewModels.Group;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class GroupCreateCommand : IRequest<GroupViewModel>
    {
        public GroupCreateViewModel Group { get; set; }
        public GroupCreateCommand(GroupCreateViewModel group)
        {
            Group = group;
        }
    }

    public class GroupCreateCommandHandler : IRequestHandler<GroupCreateCommand, GroupViewModel>
    {
        IGroupService _groupService;

        public GroupCreateCommandHandler(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public async Task<GroupViewModel> Handle(GroupCreateCommand request, CancellationToken cancellationToken)
        {
            return await _groupService.CreateGroup(request.Group);
        }
    }
}