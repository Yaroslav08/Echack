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
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(EreceiptContext db) : base(db) { }


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