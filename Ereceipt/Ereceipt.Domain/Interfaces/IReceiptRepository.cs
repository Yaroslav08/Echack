using Ereceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Ereceipt.Domain.Interfaces
{
    public interface IReceiptRepository : IRepository<Receipt>
    {
        Task<List<Receipt>> GetReceiptsByUserIdAsync(int ownerId, int skip);
        Task<List<Receipt>> GetReceiptsByShopNameAsync(int ownerId, string shopName, int skip);
        Task<Receipt> GetReceiptByIdAsync(Guid id);
        Task<List<Receipt>> GetReceiptsByGroupIdAsync(Guid groupId, int skip);
    }
}