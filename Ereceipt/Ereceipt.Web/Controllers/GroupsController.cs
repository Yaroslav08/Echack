using Ereceipt.Application.Interfaces;
using Ereceipt.Application.MediatR.Commands;
using Ereceipt.Application.MediatR.Queries;
using Ereceipt.Application.ViewModels.Group;
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

        [HttpGet("my")]
        public async Task<IActionResult> GetMyGroups()
        {
            var result = await _mediatr.Send(new GetUserGroupsQuery(GetId()));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupById(Guid id)
        {
            var result = await _mediatr.Send(new GetGroupByIdQuery(id));
            return Ok(result);
        }

        [HttpGet("{groupId}/chacks")]
        public async Task<IActionResult> GetChacksByGroupId(Guid groupId, int skip)
        {
            var result = await _mediatr.Send(new GetChacksByGroupIdQuery(groupId, skip));
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] GroupCreateViewModel model)
        {
            var result = await _mediatr.Send(new GroupCreateCommand(model));
            return Ok(result);
        }
    }
}