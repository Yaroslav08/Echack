using Ereceipt.Application.Results.BudgetCategories;
using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.BudgetCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ereceipt.Application.MediatR.Commands
{
    public class RemoveReceiptFromBudgetCategoryCommand : IRequest<BudgetCategoryResult>
    {
        public BudgetReceiptRemoveModel BudgetReceipt { get; set; }

        public RemoveReceiptFromBudgetCategoryCommand(BudgetReceiptRemoveModel budgetReceipt)
        {
            BudgetReceipt = budgetReceipt;
        }
    }

    public class RemoveReceiptFromBudgetCategoryCommandHandler : IRequestHandler<RemoveReceiptFromBudgetCategoryCommand, BudgetCategoryResult>
    {
        private readonly IBudgetCategoryService _budgetCategoryService;
        public RemoveReceiptFromBudgetCategoryCommandHandler(IBudgetCategoryService budgetCategoryService)
        {
            _budgetCategoryService = budgetCategoryService;
        }

        public async Task<BudgetCategoryResult> Handle(RemoveReceiptFromBudgetCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _budgetCategoryService.RemoveReceiptFromCategoryAsync(request.BudgetReceipt);
        }
    }
}
