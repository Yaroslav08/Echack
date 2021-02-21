using Echack.Application.Interfaces;
using Echack.Application.MediatR.Commands;
using Echack.Application.MediatR.Queries;
using Echack.Application.ViewModels.Chack;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Echack.Web.Controllers
{
    public class ChacksController : BaseController
    {
        private readonly IChackService _chackService;
        IMediator _mediator;
        public ChacksController(IChackService chackService)
        {
            _chackService = chackService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateChack([FromBody] ChackCreateViewModel model)
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
