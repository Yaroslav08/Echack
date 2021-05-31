using Ereceipt.Application.Extensions;
using Ereceipt.Application.MediatR.Commands;
using Ereceipt.Application.MediatR.Queries;
using Ereceipt.Application.ViewModels.Receipt;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace Ereceipt.Web.Controllers.V1
{
    public class ReceiptsController : ApiController
    {
        private readonly IMediator _mediator;
        public ReceiptsController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreateReceipt([FromBody] ReceiptCreateModel model)
        {
            model.IncomeRequestInit(GetId(), GetIpAddress());
            var result = await _mediator.Send(new CreateReceiptCommand(model));
            return Result(result);
        }

        [HttpPut]
        public async Task<IActionResult> EditReceipt([FromBody] ReceiptEditModel model)
        {
            model.IncomeRequestInit(GetId(), GetIpAddress());
            var result = await _mediator.Send(new EditReceiptCommand(model));
            return Result(result);
        }

        [HttpPost("to-group")]
        public async Task<IActionResult> AddReceiptToGroup([FromBody] ReceiptGroupCreateModel model)
        {
            model.IncomeRequestInit(GetId(), GetIpAddress());
            var result = await _mediator.Send(new AddReceiptToGroupCommand(model));
            return Result(result);
        }

        [HttpPost("from-group")]
        public async Task<IActionResult> RemoveReceiptFromGroup([FromBody] ReceiptGroupCreateModel model)
        {
            model.IncomeRequestInit(GetId(), GetIpAddress());
            var result = await _mediator.Send(new RemoveReceiptFromGroupCommand(model));
            return Result(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveReceipt(Guid id)
        {
            var result = await _mediator.Send(new RemoveReceiptCommand(GetId(), id));
            return Result(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetReceiptById(Guid id)
        {
            var result = await _mediator.Send(new GetReceiptByIdQuery(id));
            return Result(result);
        }

        [HttpGet("{id}/comments")]
        public async Task<IActionResult> GetCommentsOfReceipt(Guid id)
        {
            var result = await _mediator.Send(new GetCommentsOfReceiptQuery(id));
            return Result(result);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SAdmin")]
        public async Task<IActionResult> GetAllReceipts(int skip = 0)
        {
            var result = await _mediator.Send(new GetAllReceiptsQuery(skip));
            return Result(result);
        }

        [HttpGet("count")]
        [Authorize(Roles = "Admin, SAdmin")]
        public async Task<IActionResult> GetAllReceiptsCount()
        {
            var result = await _mediator.Send(new GetAllReceiptsCountQuery());
            return Result(result);
        }


        [HttpGet("my")]
        public async Task<IActionResult> GetMyReceipts(int skip = 0)
        {
            var result = await _mediator.Send(new GetMyReceiptsQuery(GetId(), skip));
            return Result(result);
        }

        [HttpGet("my/count")]
        public async Task<IActionResult> GetMyReceiptsCount()
        {
            var result = await _mediator.Send(new GetUserReceiptsCountQuery(GetId()));
            return Result(result);
        }

        [HttpGet("by-shop/{name}")]
        public async Task<IActionResult> GetReceiptsByShopName(string name, int skip = 0)
        {
            var result = await _mediator.Send(new GetReceiptsByShopNameQuery(GetId(), name, skip));
            return Result(result);
        }
    }
}