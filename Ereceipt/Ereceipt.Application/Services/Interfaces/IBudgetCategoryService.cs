using Ereceipt.Application.Results.BudgetCategories;
using Ereceipt.Application.ViewModels.BudgetCategory;
using System;
using System.Threading.Tasks;

namespace Ereceipt.Application.Services.Interfaces
{
    public interface IBudgetCategoryService
    {
        Task<BudgetCategoryResult> CreateBudgetCategoryAsync(BudgetCategoryCreateModel model);
        Task<BudgetCategoryResult> EditBudgetCategoryAsync(BudgetCategoryEditModel model);
        Task<BudgetCategoryResult> RemoveBudgetCategoryAsync(BudgetCategoryDeleteModel model);
        Task<ListBudgetCategoryResult> GetCategoriesByBudgetIdAsync(int id, Guid? groupId = null);
        Task<BudgetCategoryResult> GetCategoryByIdAsync(long id, bool withReceipts = false);
    }
}