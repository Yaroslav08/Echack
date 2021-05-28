using Ereceipt.Application.Results.Budgets;
using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.Budget;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class RemoveBudgetCommand : IRequest<BudgetResult>
    {
        public BudgetRemoveModel BudgetModel { get; set; }
        public RemoveBudgetCommand(BudgetRemoveModel budgetModel)
        {
            BudgetModel = budgetModel;
        }
    }

    public class RemoveBudgetCommandHandler : IRequestHandler<RemoveBudgetCommand, BudgetResult>
    {
        private readonly IBudgetService _budgetService;
        public RemoveBudgetCommandHandler(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        public async Task<BudgetResult> Handle(RemoveBudgetCommand request, CancellationToken cancellationToken)
        {
            return await _budgetService.RemoveBudgetAsync(request.BudgetModel);
        }
    }
}