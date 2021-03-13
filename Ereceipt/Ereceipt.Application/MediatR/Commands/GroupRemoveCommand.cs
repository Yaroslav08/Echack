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
    public class GroupRemoveCommand : IRequest<GroupViewModel>
    {
        public Guid Id { get; }
        public int UserId { get; }
        public GroupRemoveCommand(Guid id, int userId)
        {
            Id = id;
            UserId = userId;
        }
    }

    public class GroupRemoveCommandHandler : IRequestHandler<GroupRemoveCommand, GroupViewModel>
    {
        IGroupService _groupService;
        public GroupRemoveCommandHandler(IGroupService groupService)
        {
            _groupService = groupService;
        }


        public async Task<GroupViewModel> Handle(GroupRemoveCommand request, CancellationToken cancellationToken)
        {
            return await _groupService.RemoveGroup(request.Id, request.UserId);
        }
    }
}
