using Ereceipt.Application.Interfaces;
using Ereceipt.Application.ViewModels.Group;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace Ereceipt.Web.Controllers
{
    public class GroupsController : BaseController
    {
        private readonly IGroupService _groupService;
        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupById(Guid id)
        {
            var group = await _groupService.GetGroupById(id);
            return Ok(group);
        }

        [HttpGet("{groupId}/chacks")]
        public async Task<IActionResult> GetChacksByGroupId(Guid groupId, int skip)
        {
            var chacks = await _groupService.GetChacksByGroupId(groupId, skip);
            return Ok(chacks);
        }


        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] GroupCreateViewModel model)
        {
            var result = await _groupService.CreateGroup(model);
            return Ok(result);
        }
    }
}