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
    public class AddReceiptToBudgetCommand : IRequest<BudgetResult>
    {
        public BudgetReceiptCreateModel BudgetReceipt { get; set; }
        public AddReceiptToBudgetCommand(BudgetReceiptCreateModel budgetReceipt)
        {
            BudgetReceipt = budgetReceipt;
        }
    }

    public class AddReceiptToBudgetCommandHandler : IRequestHandler<AddReceiptToBudgetCommand, BudgetResult>
    {
        public readonly IBudgetService _budgetService;
        public AddReceiptToBudgetCommandHandler(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        public async Task<BudgetResult> Handle(AddReceiptToBudgetCommand request, CancellationToken cancellationToken)
        {
            return await _budgetService.AddReceiptToBudgetAsync(request.BudgetReceipt);
        }
    }
}
