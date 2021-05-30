using Ereceipt.Domain.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace Ereceipt.Application.Services.Interfaces
{
    public interface IEntityService
    {
        Task<bool> IsExistAsync<T>(Expression<Func<T, bool>> match) where T : BaseModel;
    }
}