using Ereceipt.Application.Results.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.Interfaces
{
    public interface ICommentService
    {
        Task<ListCommentResult> GetCommentsByReceiptId(Guid id);
    }
}