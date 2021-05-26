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
    public class RemoveBudgetCategoryCommand : IRequest<BudgetCategoryResult>
    {
        public BudgetCategoryDeleteModel BudgetCategory { get; set; }

        public RemoveBudgetCategoryCommand(BudgetCategoryDeleteModel budgetCategory)
        {
            BudgetCategory = budgetCategory;
        }
    }

    public class RemoveBudgetCategoryCommandHandler : IRequestHandler<RemoveBudgetCategoryCommand, BudgetCategoryResult>
    {
        private readonly IBudgetCategoryService _budgetCategoryService;

        public RemoveBudgetCategoryCommandHandler(IBudgetCategoryService budgetCategoryService)
        {
            _budgetCategoryService = budgetCategoryService;
        }

        public async Task<BudgetCategoryResult> Handle(RemoveBudgetCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _budgetCategoryService.RemoveBudgetCategoryAsync(request.BudgetCategory);
        }
    }
}
