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
    public class ReceiptsController : BaseController
    {
        IMediator _mediator;

        public ReceiptsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReceipt([FromBody] ChackCreateViewModel model)
        {
            var result = await _mediator.Send(new ChackCreateCommand(model));
            return ResultOk(result);
        }

        [HttpPost("togroup")]
        public async Task<IActionResult> AddReceiptToGroup([FromBody] ChackGroupCreateModel model)
        {
            var result = await _mediator.Send(new AddChackToGroupCommand(model));
            return ResultOk(result);
        }

        [HttpDelete("fromgroup")]
        public async Task<IActionResult> RemoveReceiptFromGroup([FromBody] ChackGroupCreateModel model)
        {
            var result = await _mediator.Send(new RemoveChackFromGroupCommand(model));
            return ResultOk(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReceiptById(Guid id)
        {
            var result = await _mediator.Send(new GetChackByIdQuery(id));
            return ResultOk(result);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, SAdmin")]
        public async Task<IActionResult> GetAllReceipts(int skip = 0)
        {
            var chaks = await _mediator.Send(new GetAllChackQuery(skip));
            return ResultOk(chaks);
        }

        [HttpGet("count")]
        //[Authorize(Roles = "Admin, SAdmin")]
        public async Task<IActionResult> GetAllReceiptsCount()
        {
            var chaks = await _mediator.Send(new GetAllChacksCountQuery());
            return ResultOk(chaks);
        }


        [HttpGet("my")]
        public async Task<IActionResult> GetMyReceipts(int skip = 0)
        {
            var chaks = await _mediator.Send(new GetMyChacksQuery(GetId(), skip));
            return ResultOk(chaks);
        }

        [HttpGet("my/count")]
        public async Task<IActionResult> GetMyReceiptsCount()
        {
            var chaks = await _mediator.Send(new GetUserChacksCountQuery(GetId()));
            return ResultOk(chaks);
        }
    }
}
