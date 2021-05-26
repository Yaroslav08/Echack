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
    public class AddReceiptToBudgetCategoryCommand : IRequest<BudgetCategoryResult>
    {
        public BudgetReceiptCreateModel BudgetReceipt { get; set; }

        public AddReceiptToBudgetCategoryCommand(BudgetReceiptCreateModel budgetReceipt)
        {
            BudgetReceipt = budgetReceipt;
        }
    }

    public class AddReceiptToBudgetCategoryCommandHandler : IRequestHandler<AddReceiptToBudgetCategoryCommand, BudgetCategoryResult>
    {
        private readonly IBudgetCategoryService _budgetCategoryService;
        public AddReceiptToBudgetCategoryCommandHandler(IBudgetCategoryService budgetCategoryService)
        {
            _budgetCategoryService = budgetCategoryService;
        }

        public async Task<BudgetCategoryResult> Handle(AddReceiptToBudgetCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _budgetCategoryService.AddReceiptToCategoryAsync(request.BudgetReceipt);
        }
    }
}
