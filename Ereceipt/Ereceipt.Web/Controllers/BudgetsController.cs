using Ereceipt.Application.Extensions;
using Ereceipt.Application.MediatR.Commands;
using Ereceipt.Application.ViewModels.Budget;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace Ereceipt.Web.Controllers
{
    public class BudgetsController : ApiController
    {
        private readonly IMediator _mediator;
        public BudgetsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CreateBudget([FromBody] BudgetCreateModel model)
        {
            model.IncomeRequestInit(GetId(), GetIpAddress());
            var result = await _mediator.Send(new CreateBudgetCommand(model));
            return Result(result);
        }

        [HttpPut]
        public async Task<IActionResult> EditBudget([FromBody] BudgetEditModel model)
        {
            model.IncomeRequestInit(GetId(), GetIpAddress());
            var result = await _mediator.Send(new EditBudgetCommand(model));
            return Result(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBudget(long id)
        {
            var model = new BudgetRemoveModel(id);
            model.IncomeRequestInit(GetId(), GetIpAddress());
            var result = await _mediator.Send(new RemoveBudgetCommand(model));
            return Result(result);
        }

        [HttpPost("receipt")]
        public async Task<IActionResult> AddReceiptToBudget([FromBody] BudgetReceiptCreateModel model)
        {
            model.IncomeRequestInit(GetId(), GetIpAddress());
            var result = await _mediator.Send(new AddReceiptToBudgetCommand(model));
            return Result(result);
        }

        [HttpDelete("receipt")]
        public async Task<IActionResult> RemoveReceiptFromBudget([FromBody] BudgetReceiptCreateModel model)
        {
            model.IncomeRequestInit(GetId(), GetIpAddress());
            var result = await _mediator.Send(new RemoveReceiptFromBudgetCommand(model));
            return Result(result);
        }
    }
}