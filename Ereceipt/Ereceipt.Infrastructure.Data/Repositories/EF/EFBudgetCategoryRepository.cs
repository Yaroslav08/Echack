using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using Ereceipt.Infrastructure.Data.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Ereceipt.Infrastructure.Data.Repositories.EF
{
    public class EFBudgetCategoryRepository : EFRepository<BudgetCategory>, IBudgetCategoryRepository
    {
        public EFBudgetCategoryRepository(EreceiptContext db) : base(db) { }

        public async Task<BudgetCategory> GetBudgetCategoryByIdAsync(long id, bool withReceipts)
        {
            if (withReceipts)
                return await db.BudgetCategories
                    .AsNoTracking()
                    .Include(x => x.Receipts)
                    .SingleOrDefaultAsync(x => x.Id == id);
            return await db.BudgetCategories
                   .AsNoTracking()
                   .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}