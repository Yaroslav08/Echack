using Ereceipt.Domain.Models;
using System.Threading.Tasks;

namespace Ereceipt.Domain.Interfaces
{
    public interface IBudgetCategoryRepository : IRepository<BudgetCategory>
    {
        Task<BudgetCategory> GetBudgetCategoryByIdAsync(long id, bool withReceipts);
    }
}