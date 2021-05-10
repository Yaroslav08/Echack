using Ereceipt.Application.Results.Budgets;
using Ereceipt.Application.ViewModels.Budget;
using System;
using System.Threading.Tasks;

namespace Ereceipt.Application.Services.Interfaces
{
    public interface IBudgetService
    {
        Task<BudgetResult> GetBudgetByIdAsync(int id, Guid groupId);
        Task<ListBudgetResult> GetActiveBudgetsAsync(Guid groupId);
        Task<ListBudgetResult> GetAllBudgetsAsync(Guid groupId);
        Task<ListBudgetResult> GetUnactiveBudgestAsync(Guid groupId);
        Task<BudgetResult> CreateBudgetAsync(BudgetCreateViewModel model);
    }
}