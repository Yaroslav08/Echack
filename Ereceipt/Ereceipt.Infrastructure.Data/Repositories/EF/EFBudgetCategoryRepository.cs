using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using Ereceipt.Infrastructure.Data.EntityFramework.Context;
namespace Ereceipt.Infrastructure.Data.Repositories.EF
{
    public class EFBudgetCategoryRepository : EFRepository<BudgetCategory>, IBudgetCategoryRepository
    {
        public EFBudgetCategoryRepository(EreceiptContext db) : base(db) { }
    }
}