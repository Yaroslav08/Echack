using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using Ereceipt.Infrastructure.Data.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Ereceipt.Infrastructure.Data.Repositories.EF
{
    public class EFCommentRepository : EFRepository<Comment>, ICommentRepository
    {
        public EFCommentRepository(EreceiptContext db) : base(db) { }

        public async Task<Comment> GetCommentWithDetailsAsync(long id)
        {
            return await db.Comments
                .AsNoTracking()
                .Include(x => x.User)
                .Include(x => x.Receipt)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> GetCountCommentsByReceiptIdAsync(Guid id)
        {
            return await db.Comments.AsNoTracking().CountAsync(x => x.ReceiptId == id);
        }

        public async Task<List<Comment>> GetReceiptCommentsAsync(Guid id)
        {
            return await db.Comments
                .AsNoTracking()
                .Where(d => d.ReceiptId == id)
                .Include(d => d.User)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }
    }
}