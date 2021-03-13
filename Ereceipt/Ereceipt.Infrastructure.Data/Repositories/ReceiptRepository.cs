using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using Ereceipt.Infrastructure.Data.Context;
using EFRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Infrastructure.Data.Repositories
{
    public class ReceiptRepository : Repository<Receipt>, IReceiptRepository
    {
        public async Task<Receipt> GetReceiptByIdAsync(Guid id)
        {
            return await db.Receipts
                .AsNoTracking()
                .Include(d => d.User)
                .Include(d => d.Group)
                .SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<Receipt>> GetReceiptsByGroupIdAsync(Guid groupId, int skip)
        {
            if (skip == 0)
                return await db.Receipts.AsNoTracking()
                    .Where(d => d.GroupId == groupId)
                    .Include(d=>d.User)
                    .OrderByDescending(d => d.CreatedAt)
                    .Take(20)
                    .ToListAsync();
            return await db.Receipts.AsNoTracking()
                    .Where(d => d.GroupId == groupId)
                    .Include(d=>d.User)
                    .OrderByDescending(d => d.CreatedAt)
                    .Skip(skip)
                    .Take(20)
                    .ToListAsync();
        }

        public async Task<List<Receipt>> GetReceiptsByMounthAsync(int ownerId, int mounth)
        {
            return await db.Receipts.AsNoTracking()
                .Where(d => d.UserId == ownerId && d.CreatedAt.Month == mounth && d.CreatedAt.Year == DateTime.Now.Year)
                .ToListAsync();
        }

        public async Task<List<Receipt>> GetReceiptsByShopNameAsync(int ownerId, string shopName, int skip = 0)
        {
            if (skip == 0)
                return await db.Receipts.AsNoTracking().Where(d => d.UserId == ownerId && d.ShopName.Contains(shopName))
                    .Take(20)
                    .ToListAsync();
            return await db.Receipts.AsNoTracking().Where(d => d.UserId == ownerId && d.ShopName.Contains(shopName))
                    .Take(20)
                    .Skip(skip)
                    .ToListAsync();
        }

        public async Task<List<Receipt>> GetReceiptsByTimeAsync(int ownerId, DateTime from, DateTime to)
        {
            return await db.Receipts.AsNoTracking()
                .Where(d => d.UserId == ownerId && d.CreatedAt >= from && d.CreatedAt <= to)
                .ToListAsync();
        }

        public async Task<List<Receipt>> GetReceiptsByUserIdAsync(int ownerId, int skip)
        {
            return await db.Receipts.AsNoTracking()
                .Where(d => d.UserId == ownerId)
                .OrderByDescending(d => d.CreatedAt)
                .Include(d => d.Group)
                .Skip(skip).Take(20)
                .ToListAsync();
        }
    }
}