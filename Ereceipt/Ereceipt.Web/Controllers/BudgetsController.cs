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
        public async Task<IActionResult> CreateBudget([FromBody] BudgetCreateViewModel model)
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
    }
}