using Ereceipt.Application.MediatR.Commands;
using Ereceipt.Application.MediatR.Queries;
using Ereceipt.Application.ViewModels.Group;
using Ereceipt.Application.ViewModels.GroupMember;
using MediatR;
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

        [HttpGet]
        //[Authorize(Roles = "Admin, SAdmin")]
        public async Task<IActionResult> GetAllGroups(int skip = 0)
        {
            var result = await _mediatr.Send(new GetAllGroupsQuery(skip));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }

        [HttpGet("my")]
        public async Task<IActionResult> GetMyGroups()
        {
            var result = await _mediatr.Send(new GetUserGroupsQuery(GetId()));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupById(Guid id)
        {
            var result = await _mediatr.Send(new GetGroupByIdQuery(id));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }

        [HttpGet("{groupId}/receipts")]
        public async Task<IActionResult> GetReceiptsByGroupId(Guid groupId, int skip)
        {
            var result = await _mediatr.Send(new GetReceiptsByGroupIdQuery(groupId, skip));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] GroupCreateViewModel model)
        {
            var result = await _mediatr.Send(new GroupCreateCommand(model));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }

        [HttpPut]
        public async Task<IActionResult> EditGroup([FromBody] GroupEditViewModel model)
        {
            var result = await _mediatr.Send(new GroupEditCommand(model));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveGroup(Guid id)
        {
            var result = await _mediatr.Send(new GroupRemoveCommand(id, GetId()));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }


        [HttpPost("members")]
        public async Task<IActionResult> AddMember([FromBody] GroupMemberCreateViewModel model)
        {
            var result = await _mediatr.Send(new AddUserToGroupCommand(model));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }


        [HttpDelete("members")]
        public async Task<IActionResult> RemoveMember([FromBody] GroupMemberCreateViewModel model)
        {
            model.UserId = GetId();
            var result = await _mediatr.Send(new RemoveUserFromGroupCommand(model));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }

        [HttpGet("{groupId}/members")]
        public async Task<IActionResult> GetGroupMembers(Guid groupId)
        {
            var result = await _mediatr.Send(new GetGroupMembersQuery(groupId));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }
    }
}