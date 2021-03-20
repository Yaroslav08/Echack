using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Results.Groups;
using Ereceipt.Application.ViewModels.GroupMember;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class AddUserToGroupCommand : IRequest<GroupMemberResult>
    {
        public GroupMemberCreateViewModel GroupData { get; }
        public AddUserToGroupCommand(GroupMemberCreateViewModel groupData)
        {
            GroupData = groupData;
        }
    }

    public class AddUserToGroupCommandHandler : IRequestHandler<AddUserToGroupCommand, GroupMemberResult>
    {
        IGroupService _groupService;
        public AddUserToGroupCommandHandler(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public async Task<GroupMemberResult> Handle(AddUserToGroupCommand request, CancellationToken cancellationToken)
        {
            return await _groupService.AddUserToGroup(request.GroupData);
        }
    }
}