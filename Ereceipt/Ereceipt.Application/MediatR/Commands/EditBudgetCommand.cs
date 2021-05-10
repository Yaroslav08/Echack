using Ereceipt.Application.Results.Budgets;
using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.Budget;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class EditBudgetCommand : IRequest<BudgetResult>
    {
        public BudgetEditModel Budget { get; set; }
        public EditBudgetCommand(BudgetEditModel budget)
        {
            Budget = budget;
        }
    }

    public class EditBudgetCommandHandler : IRequestHandler<EditBudgetCommand, BudgetResult>
    {
        private readonly IBudgetService _budgetService;
        public EditBudgetCommandHandler(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        public async Task<BudgetResult> Handle(EditBudgetCommand request, CancellationToken cancellationToken)
        {
            return await _budgetService.EditBudgetAsync(request.Budget);
        }
    }
}