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
    public class GroupEditCommand : IRequest<GroupViewModel>
    {
        public GroupEditViewModel Group { get; }
        public GroupEditCommand(GroupEditViewModel group)
        {
            Group = group;
        }
    }

    public class GroupEditCommandHandler : IRequestHandler<GroupEditCommand, GroupViewModel>
    {
        IGroupService _groupService;
        public GroupEditCommandHandler(IGroupService groupService)
        {
            _groupService = groupService;
        }


        public async Task<GroupViewModel> Handle(GroupEditCommand request, CancellationToken cancellationToken)
        {
            if (await _groupService.CanEditGroup(request.Group.Id, request.Group.UserId))
                return await _groupService.EditGroup(request.Group);
            return null;
        }
    }
}
