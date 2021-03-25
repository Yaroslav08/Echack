using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Results.Groups;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ereceipt.Application.MediatR.Commands
{
    public class GroupRemoveCommand : IRequest<GroupResult>
    {
        public Guid Id { get; }
        public int UserId { get; }
        public GroupRemoveCommand(Guid id, int userId)
        {
            Id = id;
            UserId = userId;
        }
    }

    public class GroupRemoveCommandHandler : IRequestHandler<GroupRemoveCommand, GroupResult>
    {
        IGroupService _groupService;
        public GroupRemoveCommandHandler(IGroupService groupService)
        {
            _groupService = groupService;
        }


        public async Task<GroupResult> Handle(GroupRemoveCommand request, CancellationToken cancellationToken)
        {
            return await _groupService.RemoveGroup(request.Id, request.UserId);
        }
    }
}
