using Ereceipt.Application.Interfaces;
using Ereceipt.Application.MediatR.Commands;
using Ereceipt.Application.MediatR.Queries;
using Ereceipt.Application.ViewModels.Group;
using Ereceipt.Application.ViewModels.GroupMember;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace Ereceipt.Web.Controllers
{
    public class GroupsController : BaseController
    {
        private IMediator _mediatr;
        public GroupsController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet("my")]
        [Authorize]
        public async Task<IActionResult> GetMyGroups()
        {
            var result = await _mediatr.Send(new GetUserGroupsQuery(GetId()));
            return ResultOk(result);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetGroupById(Guid id)
        {
            var result = await _mediatr.Send(new GetGroupByIdQuery(id));
            return ResultOk(result);
        }

        [HttpGet("{groupId}/receipts")]
        [Authorize]
        public async Task<IActionResult> GetReceiptsByGroupId(Guid groupId, int skip)
        {
            var result = await _mediatr.Send(new GetReceiptsByGroupIdQuery(groupId, skip));
            return ResultOk(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateGroup([FromBody] GroupCreateViewModel model)
        {
            var result = await _mediatr.Send(new GroupCreateCommand(model));
            return ResultOk(result);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> EditGroup([FromBody] GroupEditViewModel model)
        {
            var result = await _mediatr.Send(new GroupEditCommand(model));
            return ResultOk(result);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> RemoveGroup(Guid id)
        {
            var result = await _mediatr.Send(new GroupRemoveCommand(id, GetId()));
            return ResultOk(result);
        }


        [HttpPost("members")]
        public async Task<IActionResult> AddMember([FromBody] GroupMemberCreateViewModel model)
        {
            var result = await _mediatr.Send(new AddUserToGroupCommand(model));
            return ResultOk(result);
        }


        [HttpDelete("members")]
        public async Task<IActionResult> RemoveMember([FromBody] GroupMemberCreateViewModel model)
        {
            model.UserId = GetId();
            var result = await _mediatr.Send(new RemoveUserFromGroupCommand(model));
            return ResultOk(result);
        }

        [HttpGet("{groupId}/members")]
        public async Task<IActionResult> GetGroupMembers(Guid groupId)
        {
            var result = await _mediatr.Send(new GetGroupMembersQuery(groupId));
            return ResultOk(result);
        }
    }
}