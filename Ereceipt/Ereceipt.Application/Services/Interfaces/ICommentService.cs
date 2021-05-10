using Ereceipt.Application.Results.Comments;
using Ereceipt.Application.ViewModels.Comment;
using System;
using System.Threading.Tasks;
namespace Ereceipt.Application.Services.Interfaces
{
    public interface ICommentService
    {
        Task<ListCommentResult> GetCommentsByReceiptIdAsync(Guid id);
        Task<CommentResult> GetCommentWithDetailsAsync(long id);
        Task<CommentResult> CreateCommentAsync(CommentCreateModel model);
        Task<CommentResult> EditCommentAsync(CommentEditModel model);
        Task<CommentResult> RemoveCommentAsync(int userId, long commentId);
    }
}