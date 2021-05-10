using Ereceipt.Application.ViewModels.Budget;
namespace Ereceipt.Application.Results.Budgets
{
    public class BudgetResult : Result
    {
        public BudgetResult(BudgetViewModel model) : base(model) { }
        public BudgetResult(string error) : base(error) { }
    }
}