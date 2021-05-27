using Ereceipt.Application.Extensions;
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
    public class GroupsController : ApiController
    {
        private readonly IMediator _mediatr;
        public GroupsController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }


        #region Groups

        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] GroupCreateModel model)
        {
            model.IncomeRequestInit(GetId(), GetIpAddress());
            var result = await _mediatr.Send(new CreateGroupCommand(model));
            return Result(result);
        }

        [HttpPut]
        public async Task<IActionResult> EditGroup([FromBody] GroupEditModel model)
        {
            model.IncomeRequestInit(GetId(), GetIpAddress());
            var result = await _mediatr.Send(new EditGroupCommand(model));
            return Result(result);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveGroup(Guid id)
        {
            var result = await _mediatr.Send(new RemoveGroupCommand(id, GetId()));
            return Result(result);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SAdmin")]
        public async Task<IActionResult> GetAllGroups(int skip = 0)
        {
            var result = await _mediatr.Send(new GetAllGroupsQuery(skip));
            return Result(result);
        }

        [HttpGet("my")]
        public async Task<IActionResult> GetMyGroups()
        {
            var result = await _mediatr.Send(new GetUserGroupsQuery(GetId()));
            return Result(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupById(Guid id)
        {
            var result = await _mediatr.Send(new GetGroupByIdQuery(id));
            return Result(result);
        }

        #endregion


        #region Receipts

        [HttpGet("{groupId}/receipts")]
        public async Task<IActionResult> GetReceiptsByGroupId(Guid groupId, int skip)
        {
            var result = await _mediatr.Send(new GetReceiptsByGroupIdQuery(groupId, skip));
            return Result(result);
        }

        #endregion


        #region GroupMembers

        [HttpPost("members")]
        public async Task<IActionResult> AddMember([FromBody] GroupMemberCreateModel model)
        {
            model.IncomeRequestInit(GetId(), GetIpAddress());
            var result = await _mediatr.Send(new AddUserToGroupCommand(model));
            return Result(result);
        }

        [HttpPut("members")]
        public async Task<IActionResult> EditMember([FromBody] GroupMemberEditModel model)
        {
            model.IncomeRequestInit(GetId(), GetIpAddress());
            var result = await _mediatr.Send(new EditMemberCommand(model));
            return Result(result);
        }

        [HttpDelete("members")]
        public async Task<IActionResult> RemoveMember([FromBody] GroupMemberRemoveModel model)
        {
            model.IncomeRequestInit(GetId(), GetIpAddress());
            var result = await _mediatr.Send(new RemoveUserFromGroupCommand(model));
            return Result(result);
        }

        [HttpGet("{groupId}/members")]
        public async Task<IActionResult> GetGroupMembers(Guid groupId)
        {
            var result = await _mediatr.Send(new GetGroupMembersQuery(groupId));
            return Result(result);
        }

        #endregion


        #region Budgets

        [HttpGet("{groupId}/budgets")]
        public async Task<IActionResult> GetAllBudgets(Guid groupId)
        {
            var result = await _mediatr.Send(new GetAllBudgetsQuery(groupId));
            return Result(result);
        }

        [HttpGet("{groupId}/budgets/{id}")]
        public async Task<IActionResult> GetBudgetById(Guid groupId, int id)
        {
            var result = await _mediatr.Send(new GetBudgetByIdQuery(id, groupId));
            return Result(result);
        }

        [HttpGet("{groupId}/budgets/active")]
        public async Task<IActionResult> GetActiveBudgets(Guid groupId)
        {
            var result = await _mediatr.Send(new GetActiveBudgetsQuery(groupId));
            return Result(result);
        }

        [HttpGet("{groupId}/budgets/un-active")]
        public async Task<IActionResult> GetUnactiveBudgets(Guid groupId)
        {
            var result = await _mediatr.Send(new GetUnactiveBudgestQuery(groupId));
            return Result(result);
        }

        #endregion
    }
}