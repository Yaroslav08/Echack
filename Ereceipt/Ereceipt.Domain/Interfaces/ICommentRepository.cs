using Ereceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ereceipt.Domain.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<List<Comment>> GetReceiptCommentsAsync(Guid id);
    }
}