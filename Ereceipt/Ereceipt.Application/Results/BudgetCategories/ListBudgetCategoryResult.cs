using Ereceipt.Application.ViewModels.BudgetCategory;
using System.Collections.Generic;
namespace Ereceipt.Application.Results.BudgetCategories
{
    public class ListBudgetCategoryResult : Result
    {
        public ListBudgetCategoryResult(List<BudgetCategoryViewModel> models) : base(models) { }

        public ListBudgetCategoryResult(string error) : base(error) { }
    }
}