using Ereceipt.Application.MediatR.Commands;
using Ereceipt.Application.MediatR.Queries;
using Ereceipt.Application.ViewModels.Chack;
using MediatR;
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
        public async Task<IActionResult> CreatEreceipt([FromBody] ChackCreateViewModel model)
        {
            var result = await _mediator.Send(new ChackCreateCommand(model));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChackById(Guid id)
        {
            var result = await _mediator.Send(new GetChackByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChacks(int skip = 0)
        {
            var chaks = await _mediator.Send(new GetAllChackQuery(skip));
            return Ok(chaks);
        }
    }
}
