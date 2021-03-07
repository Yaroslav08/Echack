using Ereceipt.Application.MediatR.Commands;
using Ereceipt.Application.MediatR.Queries;
using Ereceipt.Application.ViewModels.Chack;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ereceipt.Web.Controllers
{
    public class ChacksController : BaseController
    {
        IMediator _mediator;

        public ChacksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEreceipt([FromBody] ChackCreateViewModel model)
        {
            var result = await _mediator.Send(new ChackCreateCommand(model));
            return Ok(result);
        }

        [HttpPost("togroup")]
        public async Task<IActionResult> AddChackToGroup([FromBody] ChackGroupCreateModel model)
        {
            var result = await _mediator.Send(new AddChackToGroupCommand(model));
            return Ok(result);
        }

        [HttpDelete("fromgroup")]
        public async Task<IActionResult> RemoveChackFromGroup([FromBody] ChackGroupCreateModel model)
        {
            var result = await _mediator.Send(new RemoveChackFromGroupCommand(model));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChackById(Guid id)
        {
            var result = await _mediator.Send(new GetChackByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, SAdmin")]
        public async Task<IActionResult> GetAllChacks(int skip = 0)
        {
            var chaks = await _mediator.Send(new GetAllChackQuery(skip));
            return Ok(chaks);
        }

        [HttpGet("my")]
        public async Task<IActionResult> GetMyChaks(int skip = 0)
        {
            var chaks = await _mediator.Send(new GetMyChacksQuery(GetId(), skip));
            return Ok(chaks);
        }
    }
}
