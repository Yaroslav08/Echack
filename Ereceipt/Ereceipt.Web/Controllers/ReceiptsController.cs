using Ereceipt.Application.MediatR.Commands;
using Ereceipt.Application.MediatR.Queries;
using Ereceipt.Application.ViewModels.Receipt;
using MediatR;
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
        public async Task<IActionResult> CreateReceipt([FromBody] ReceiptCreateViewModel model)
        {
            var result = await _mediator.Send(new ReceiptCreateCommand(model));
            return ResultOk(result);
        }

        [HttpPost("togroup")]
        public async Task<IActionResult> AddReceiptToGroup([FromBody] ReceiptGroupCreateModel model)
        {
            var result = await _mediator.Send(new AddReceiptToGroupCommand(model));
            return ResultOk(result);
        }

        [HttpDelete("fromgroup")]
        public async Task<IActionResult> RemoveReceiptFromGroup([FromBody] ReceiptGroupCreateModel model)
        {
            var result = await _mediator.Send(new RemoveReceiptFromGroupCommand(model));
            return ResultOk(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReceiptById(Guid id)
        {
            var result = await _mediator.Send(new GetReceiptByIdQuery(id));
            return ResultOk(result);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, SAdmin")]
        public async Task<IActionResult> GetAllReceipts(int skip = 0)
        {
            var chaks = await _mediator.Send(new GetAllReceiptsQuery(skip));
            return ResultOk(chaks);
        }

        [HttpGet("count")]
        //[Authorize(Roles = "Admin, SAdmin")]
        public async Task<IActionResult> GetAllReceiptsCount()
        {
            var chaks = await _mediator.Send(new GetAllReceiptsCountQuery());
            return ResultOk(chaks);
        }


        [HttpGet("my")]
        public async Task<IActionResult> GetMyReceipts(int skip = 0)
        {
            var chaks = await _mediator.Send(new GetMyReceiptsQuery(GetId(), skip));
            return ResultOk(chaks);
        }

        [HttpGet("my/count")]
        public async Task<IActionResult> GetMyReceiptsCount()
        {
            var chaks = await _mediator.Send(new GetUserReceiptsCountQuery(GetId()));
            return ResultOk(chaks);
        }
    }
}
