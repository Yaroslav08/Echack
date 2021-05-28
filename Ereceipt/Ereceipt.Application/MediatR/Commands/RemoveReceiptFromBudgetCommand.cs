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
    public class RemoveReceiptFromBudgetCommand : IRequest<BudgetResult>
    {
        public BudgetReceiptCreateModel BudgetReceipt { get; set; }
        public RemoveReceiptFromBudgetCommand(BudgetReceiptCreateModel budgetReceipt)
        {
            BudgetReceipt = budgetReceipt;
        }
    }

    public class RemoveReceiptFromBudgetCommandHandler : IRequestHandler<RemoveReceiptFromBudgetCommand, BudgetResult>
    {
        private readonly IBudgetService _budgetService;
        public RemoveReceiptFromBudgetCommandHandler(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        public async Task<BudgetResult> Handle(RemoveReceiptFromBudgetCommand request, CancellationToken cancellationToken)
        {
            return await _budgetService.RemoveReceiptFromBudgetAsync(request.BudgetReceipt);
        }
    }
}
