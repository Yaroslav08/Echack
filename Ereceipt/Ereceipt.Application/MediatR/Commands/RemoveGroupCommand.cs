using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.Results.Groups;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ereceipt.Application.MediatR.Commands
{
    public class RemoveGroupCommand : IRequest<GroupResult>
    {
        public Guid Id { get; }
        public int UserId { get; }
        public RemoveGroupCommand(Guid id, int userId)
        {
            Id = id;
            UserId = userId;
        }
    }

    public class GroupRemoveCommandHandler : IRequestHandler<RemoveGroupCommand, GroupResult>
    {
        IGroupService _groupService;
        public GroupRemoveCommandHandler(IGroupService groupService)
        {
            _groupService = groupService;
        }


        public async Task<GroupResult> Handle(RemoveGroupCommand request, CancellationToken cancellationToken)
        {
            return await _groupService.RemoveGroupAsync(request.Id, request.UserId);
        }
    }
}
