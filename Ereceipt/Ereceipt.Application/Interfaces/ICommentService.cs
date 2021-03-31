using Ereceipt.Application.Results.Comments;
using Ereceipt.Application.ViewModels.Comment;
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
        Task<CommentResult> GetCommentWithDetails(long id);
        Task<CommentResult> CreateComment(CommentCreateViewModel model);
        Task<CommentResult> EditComment(CommentEditViewModel model);
        Task<CommentResult> RemoveComment(int userId, long commentId);
    }
}