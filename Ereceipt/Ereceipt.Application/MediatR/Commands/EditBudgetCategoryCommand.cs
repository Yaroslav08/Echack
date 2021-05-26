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
    public class EditBudgetCategoryCommand : IRequest<BudgetCategoryResult>
    {
        public BudgetCategoryEditModel BudgetCategory { get; set; }
        public EditBudgetCategoryCommand(BudgetCategoryEditModel budgetCategory)
        {
            BudgetCategory = budgetCategory;
        }
    }

    public class EditBudgetCategoryCommandHandler : IRequestHandler<EditBudgetCategoryCommand, BudgetCategoryResult>
    {
        private readonly IBudgetCategoryService _budgetCategoryService;
        public EditBudgetCategoryCommandHandler(IBudgetCategoryService budgetCategoryService)
        {
            _budgetCategoryService = budgetCategoryService;
        }

        public async Task<BudgetCategoryResult> Handle(EditBudgetCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _budgetCategoryService.EditBudgetCategoryAsync(request.BudgetCategory);
        }
    }
}
