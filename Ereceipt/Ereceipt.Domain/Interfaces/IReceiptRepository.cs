﻿using Ereceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Ereceipt.Domain.Interfaces
{
    public interface IReceiptRepository : IRepository<Receipt>
    {
        Task<List<Receipt>> GetReceiptsByUserIdAsync(int ownerId, int skip);
        Task<List<Receipt>> GetReceiptsByMounthAsync(int ownerId, int mounth);
        Task<List<Receipt>> GetReceiptsByTimeAsync(int ownerId, DateTime from, DateTime to);
        Task<List<Receipt>> GetReceiptsByShopNameAsync(int ownerId, string shopName, int skip);
        Task<Receipt> GetReceiptByIdAsync(Guid id);
        Task<int> GetCountCommentsByReceiptIdAsync(Guid id);
        Task<List<Receipt>> GetReceiptsByGroupIdAsync(Guid groupId, int skip);
    }
}