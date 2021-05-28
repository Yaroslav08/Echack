using Ereceipt.Application.Results.Budgets;
using Ereceipt.Application.Results.Receipts;
using Ereceipt.Application.ViewModels.Budget;
using System;
using System.Threading.Tasks;

namespace Ereceipt.Application.Services.Interfaces
{
    public interface IBudgetService
    {
        Task<BudgetResult> CreateBudgetAsync(BudgetCreateModel model);
        Task<BudgetResult> EditBudgetAsync(BudgetEditModel budgetModel);
        Task<BudgetResult> AddReceiptToBudgetAsync(BudgetReceiptCreateModel model);
        Task<BudgetResult> RemoveReceiptFromBudgetAsync(BudgetReceiptCreateModel model);
        Task<BudgetResult> GetBudgetByIdAsync(int id, Guid groupId);
        Task<ListBudgetResult> GetActiveBudgetsAsync(Guid groupId);
        Task<ListBudgetResult> GetAllBudgetsAsync(Guid groupId);
        Task<ListBudgetResult> GetUnactiveBudgestAsync(Guid groupId);
        Task<ListReceiptResult> GetReceiptsByBudgetAsync(Guid groupId, long budgetId, int skip);
    }
}