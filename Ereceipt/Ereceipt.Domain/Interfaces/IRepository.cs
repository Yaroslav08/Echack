using Ereceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseModel
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task CreateRangeAsync(List<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(List<TEntity> entities);
        Task<TEntity> RemoveAsync(TEntity entity);
        Task RemoveRangeAsync(List<TEntity> entities);
        Task<TEntity> GetByIdAsTrackingAsync(object Id);
        Task<List<TEntity>> GetAllAsync(int count, int offset);
        Task<TEntity> FirstAsync();
        Task<TEntity> LastAsync();
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<TEntity, bool>> match);
        Task<long> CountLongAsync();
        Task<long> CountLongAsync(Expression<Func<TEntity, bool>> match);
        Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> match);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match);
        Task<TEntity> FindAsTrackingAsync(Expression<Func<TEntity, bool>> match);
        Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> match);
        Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> match, int count, int skip);
        Task<List<TEntity>> FindListAsTrackingAsync(Expression<Func<TEntity, bool>> match);
    }
}