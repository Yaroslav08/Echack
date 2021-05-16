using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using Ereceipt.Infrastructure.Data.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace Ereceipt.Infrastructure.Data.Repositories.EF
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        protected EreceiptContext db;
        protected DbSet<TEntity> dbSet;

        public EFRepository(EreceiptContext _db)
        {
            db = _db;
            dbSet = db.Set<TEntity>();
        }

        public async Task<int> CountAsync()
        {
            return await db.Set<TEntity>().AsNoTracking().CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().AsNoTracking().CountAsync(match);
        }

        public async Task<long> CountLongAsync()
        {
            return await db.Set<TEntity>().AsNoTracking().LongCountAsync();
        }

        public async Task<long> CountLongAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().AsNoTracking().LongCountAsync(match);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await db.Set<TEntity>().AddAsync(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task CreateRangeAsync(List<TEntity> entities)
        {
            await db.Set<TEntity>().AddRangeAsync(entities);
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public async Task<TEntity> FindAsTrackingAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().FirstOrDefaultAsync(match);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(match);
        }

        public async Task<List<TEntity>> FindListAsTrackingAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().Where(match).ToListAsync();
        }

        public async Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().AsNoTracking().Where(match).ToListAsync();
        }

        public async Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> match, int count, int skip)
        {
            return await db.Set<TEntity>().AsNoTracking().Where(match).Skip(skip).Take(count).ToListAsync();
        }

        public async Task<TEntity> FirstAsync()
        {
            return await db.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(int count, int offset)
        {
            return await db.Set<TEntity>()
                .AsNoTracking()
                .OrderByDescending(d => d.CreatedAt)
                .Skip(offset).Take(count)
                .ToListAsync();
        }

        public async Task<TEntity> GetByIdAsTrackingAsync(object Id)
        {
            return await db.Set<TEntity>().FindAsync(Id);
        }

        public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(match) != null ? true : false;
        }

        public async Task<TEntity> LastAsync()
        {
            return await db.Set<TEntity>().AsNoTracking().LastOrDefaultAsync();
        }

        public async Task<TEntity> RemoveAsync(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task RemoveRangeAsync(List<TEntity> entities)
        {
            db.Set<TEntity>().RemoveRange(entities);
            await db.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            db.Set<TEntity>().Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateRangeAsync(List<TEntity> entities)
        {
            db.Set<TEntity>().UpdateRange(entities);
            await db.SaveChangesAsync();
        }
    }
}