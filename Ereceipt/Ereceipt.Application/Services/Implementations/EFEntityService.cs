using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Domain.Models;
using Ereceipt.Infrastructure.Data.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Ereceipt.Application.Services.Implementations
{
    public class EFEntityService : IEntityService
    {
        private readonly EreceiptContext _db;
        public EFEntityService(EreceiptContext db)
        {
            _db = db;
        }

        public async Task<bool> IsExistAsync<T>(Expression<Func<T, bool>> match) where T : BaseModel
        {
            var models = await _db.Set<T>()
                .AsNoTracking()
                .Where(match)
                .Select(x => new BaseModel { CreatedBy = x.CreatedBy, CreatedAt = x.CreatedAt })
                .ToListAsync();
            if (models == null || models.Count == 0)
                return false;
            return true;
        }
    }
}
