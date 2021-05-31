namespace Ereceipt.Application.ViewModels.Budget
{
    public class BudgetRemoveModel : RequestModel
    {
        public long BudgetId { get; set; }
        public BudgetRemoveModel(long budgetId)
        {
            BudgetId = budgetId;
        }
    }
}
