using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using Ereceipt.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ereceipt.Infrastructure.Data.Repositories
{
    public class BudgetRepository : Repository<Budget>, IBudgetRepository
    {
        public BudgetRepository(EreceiptContext db) : base(db) { }

        public async Task<List<Budget>> GetActiveBudgetsAsync(Guid id)
        {
            var todayDate = DateTime.UtcNow;
            return await db.Budgets
                .AsNoTracking()
                .Where(x => x.GroupId == id && (x.StartPeriod < todayDate && x.EndPeriod > todayDate))
                .ToListAsync();
        }
    }
}