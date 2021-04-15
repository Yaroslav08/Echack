using Ereceipt.Application.MediatR.Commands;
using Ereceipt.Application.MediatR.Queries;
using Ereceipt.Application.ViewModels.Receipt;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace Ereceipt.Web.Controllers
{
    public class ReceiptsController : ApiController
    {
        IMediator _mediator;

        public ReceiptsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReceipt([FromBody] ReceiptCreateViewModel model)
        {
            model.UserId = GetId();
            model.IP = GetIpAddress();
            var result = await _mediator.Send(new ReceiptCreateCommand(model));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }

        [HttpPut]
        public async Task<IActionResult> EditReceipt([FromBody] ReceiptEditViewModel model)
        {
            model.UserId = GetId();
            model.IP = GetIpAddress();
            var result = await _mediator.Send(new ReceiptEditCommand(model));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }

        [HttpPost("togroup")]
        public async Task<IActionResult> AddReceiptToGroup([FromBody] ReceiptGroupCreateModel model)
        {
            model.UserId = GetId();
            model.IP = GetIpAddress();
            var result = await _mediator.Send(new AddReceiptToGroupCommand(model));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }

        [HttpPost("fromgroup")]
        public async Task<IActionResult> RemoveReceiptFromGroup([FromBody] ReceiptGroupCreateModel model)
        {
            model.UserId = GetId();
            model.IP = GetIpAddress();
            var result = await _mediator.Send(new RemoveReceiptFromGroupCommand(model));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveReceipt(Guid id)
        {
            var result = await _mediator.Send(new RemoveReceiptCommand(GetId(), id));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetReceiptById(Guid id)
        {
            var result = await _mediator.Send(new GetReceiptByIdQuery(id));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }

        [HttpGet("{id}/comments")]
        public async Task<IActionResult> GetCommentsOfReceipt(Guid id)
        {
            var result = await _mediator.Send(new GetCommentsOfReceiptQuery(id));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, SAdmin")]
        public async Task<IActionResult> GetAllReceipts(int skip = 0)
        {
            var result = await _mediator.Send(new GetAllReceiptsQuery(skip));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }

        [HttpGet("count")]
        //[Authorize(Roles = "Admin, SAdmin")]
        public async Task<IActionResult> GetAllReceiptsCount()
        {
            var result = await _mediator.Send(new GetAllReceiptsCountQuery());
            return ResultOk(result);
        }


        [HttpGet("my")]
        public async Task<IActionResult> GetMyReceipts(int skip = 0)
        {
            var result = await _mediator.Send(new GetMyReceiptsQuery(GetId(), skip));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }

        [HttpGet("my/count")]
        public async Task<IActionResult> GetMyReceiptsCount()
        {
            var result = await _mediator.Send(new GetUserReceiptsCountQuery(GetId()));
            return ResultOk(result);
        }
    }
}