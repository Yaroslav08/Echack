using Ereceipt.Application.ViewModels.BudgetCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ereceipt.Application.Extensions;
using Ereceipt.Application.MediatR.Commands;

namespace Ereceipt.Web.Controllers
{

    public class BudgetCategoriesController : ApiController
    {
        private readonly IMediator _mediator;
        public BudgetCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBudgetCategory([FromBody] BudgetCategoryCreateModel model)
        {
            model.IncomeRequestInit(GetId(), GetIpAddress());
            var result = await _mediator.Send(new CreateBudgetCategoryCommand(model));
            return Result(result);
        }

        [HttpPut]
        public async Task<IActionResult> EditBudgetCategory([FromBody] BudgetCategoryEditModel model)
        {
            model.IncomeRequestInit(GetId(), GetIpAddress());
            var result = await _mediator.Send(new EditBudgetCategoryCommand(model));
            return Result(result);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBudgetCategory([FromBody] BudgetCategoryDeleteModel model)
        {
            model.IncomeRequestInit(GetId(), GetIpAddress());
            var result = await _mediator.Send(new RemoveBudgetCategoryCommand(model));
            return Result(result);
        }



        [HttpPost("new-receipt")]
        public async Task<IActionResult> AddReceiptToBudgetCategory([FromBody] BudgetReceiptCreateModel model)
        {
            model.IncomeRequestInit(GetId(), GetIpAddress());
            var result = await _mediator.Send(new AddReceiptToBudgetCategoryCommand(model));
            return Result(result);
        }

        [HttpDelete("remove-receipt")]
        public async Task<IActionResult> RemoveReceiptFromBudgetCategory([FromBody] BudgetReceiptRemoveModel model)
        {
            model.IncomeRequestInit(GetId(), GetIpAddress());
            var result = await _mediator.Send(new RemoveReceiptFromBudgetCategoryCommand(model));
            return Result(result);
        }
    }
}
