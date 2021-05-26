using Ereceipt.Application.Results.BudgetCategories;
using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.BudgetCategory;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class CreateBudgetCategoryCommand : IRequest<BudgetCategoryResult>
    {
        public BudgetCategoryCreateModel BudgetCategory { get; set; }

        public CreateBudgetCategoryCommand(BudgetCategoryCreateModel budgetCategory)
        {
            BudgetCategory = budgetCategory;
        }
    }

    public class CreateBudgetCategoryCommandHandler : IRequestHandler<CreateBudgetCategoryCommand, BudgetCategoryResult>
    {
        private readonly IBudgetCategoryService _budgetCategoryService;
        public CreateBudgetCategoryCommandHandler(IBudgetCategoryService budgetCategoryService)
        {
            _budgetCategoryService = budgetCategoryService;
        }

        public async Task<BudgetCategoryResult> Handle(CreateBudgetCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _budgetCategoryService.CreateBudgetCategoryAsync(request.BudgetCategory);
        }
    }
}