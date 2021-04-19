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
        Task<ListCommentResult> GetCommentsByReceiptIdAsync(Guid id);
        Task<CommentResult> GetCommentWithDetailsAsync(long id);
        Task<CommentResult> CreateCommentAsync(CommentCreateViewModel model);
        Task<CommentResult> EditCommentAsync(CommentEditViewModel model);
        Task<CommentResult> RemoveCommentAsync(int userId, long commentId);
    }
}