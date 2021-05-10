using Ereceipt.Application.ViewModels.Budget;
using System.Collections.Generic;
namespace Ereceipt.Application.Results.Budgets
{
    public class ListBudgetResult : Result
    {
        public ListBudgetResult(List<BudgetViewModel> models) : base(models) { }
        public ListBudgetResult(string error) : base(error) { }
    }
}