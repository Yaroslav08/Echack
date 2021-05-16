using Ereceipt.Application.ViewModels.BudgetCategory;
namespace Ereceipt.Application.Results.BudgetCategories
{
    public class BudgetCategoryResult : Result
    {
        public BudgetCategoryResult(BudgetCategoryViewModel model) : base(model) { }

        public BudgetCategoryResult(string error) : base(error) { }
    }
}