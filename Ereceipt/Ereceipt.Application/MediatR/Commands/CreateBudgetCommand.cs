using Ereceipt.Application.Results.Budgets;
using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.Budget;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class CreateBudgetCommand : IRequest<BudgetResult>
    {
        public CreateBudgetCommand(BudgetCreateModel model)
        {
            Budget = model;
        }
        public BudgetCreateModel Budget { get; set; }
    }
    public class CreateBudgetCommandHandler : IRequestHandler<CreateBudgetCommand, BudgetResult>
    {
        private readonly IBudgetService _budgetService;
        public CreateBudgetCommandHandler(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        public async Task<BudgetResult> Handle(CreateBudgetCommand request, CancellationToken cancellationToken)
        {
            return await _budgetService.CreateBudgetAsync(request.Budget);
        }
    }
}