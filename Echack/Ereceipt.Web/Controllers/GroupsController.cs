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

        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] GroupCreateViewModel model)
        {
            var result = await _groupService.CreateGroup(model);
            return Ok(result);
        }
    }
}