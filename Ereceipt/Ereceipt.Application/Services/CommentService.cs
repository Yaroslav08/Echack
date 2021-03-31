using AutoMapper;
using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Results.Comments;
using Ereceipt.Application.ViewModels.Comment;
using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.Services
{
    public class CommentService : ICommentService
    {
        ICommentRepository _commentRepository;
        IMapper _mapper;
        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<CommentResult> CreateComment(CommentCreateViewModel model)
        {
            var comment = new Comment
            {
                Text = model.Text,
                ReceiptId = model.ReceiptId,
                UserId = model.UserId,
                CreatedBy = model.UserId.ToString(),
                CreatedAt = DateTime.UtcNow
            };
            return new CommentResult(_mapper.Map<CommentViewModel>(await _commentRepository.CreateAsync(comment)));
        }

        public async Task<CommentResult> EditComment(CommentEditViewModel model)
        {
            var commentToEdit = await _commentRepository.FindAsTrackingAsync(x => x.Id == model.Id);
            if (commentToEdit == null)
                return new CommentResult("Comment not found");
            if (commentToEdit.UserId != model.UserId)
                return new CommentResult("Access Denited");
            commentToEdit.Text = model.Text;
            commentToEdit.UpdatedAt = DateTime.UtcNow;
            commentToEdit.UpdatedBy = model.UserId.ToString();
            return new CommentResult(_mapper.Map<CommentViewModel>(await _commentRepository.UpdateAsync(commentToEdit)));
        }

        public async Task<ListCommentResult> GetCommentsByReceiptId(Guid id)
        {
            return new ListCommentResult(_mapper.Map<List<CommentViewModel>>(await _commentRepository.GetReceiptCommentsAsync(id)));
        }

        public async Task<CommentResult> RemoveComment(int userId, long commentId)
        {
            var comment = await _commentRepository.FindAsTrackingAsync(x => x.Id == commentId);
            if (comment == null)
                return new CommentResult("Comment not found");
            if (comment.UserId != userId)
                return new CommentResult("Access denited");
            return new CommentResult(_mapper.Map<CommentViewModel>(await _commentRepository.RemoveAsync(comment)));
        }
    }
}