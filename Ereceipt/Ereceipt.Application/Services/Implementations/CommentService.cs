using AutoMapper;
using Ereceipt.Application.Extensions;
using Ereceipt.Application.Results.Comments;
using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.Comment;
using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Ereceipt.Application.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IEntityService _entityService;
        private readonly IMapper _mapper;
        public CommentService(ICommentRepository commentRepository, IMapper mapper, IEntityService entityService)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _entityService = entityService;
        }

        public async Task<CommentResult> CreateCommentAsync(CommentCreateModel model)
        {
            if (!await _entityService.IsExistAsync<Receipt>(x => x.Id == model.ReceiptId))
                return new CommentResult("Receipt not found");
            var comment = new Comment
            {
                Text = model.Text,
                ReceiptId = model.ReceiptId,
                UserId = model.UserId
            };
            comment.SetInitData(model);
            return new CommentResult(_mapper.Map<CommentViewModel>(await _commentRepository.CreateAsync(comment)));
        }

        public async Task<CommentResult> EditCommentAsync(CommentEditModel model)
        {
            var commentToEdit = await _commentRepository.FindAsTrackingAsync(x => x.Id == model.Id);
            if (commentToEdit == null)
                return new CommentResult("Comment not found");
            if (commentToEdit.UserId != model.UserId)
                return new CommentResult("Access Denited");
            commentToEdit.Text = model.Text;
            commentToEdit.SetUpdateData(model);
            return new CommentResult(_mapper.Map<CommentViewModel>(await _commentRepository.UpdateAsync(commentToEdit)));
        }

        public async Task<ListCommentResult> GetCommentsByReceiptIdAsync(Guid id)
        {
            return new ListCommentResult(_mapper.Map<List<CommentViewModel>>(await _commentRepository.GetReceiptCommentsAsync(id)));
        }

        public async Task<CommentResult> GetCommentWithDetailsAsync(long id)
        {
            return new CommentResult(_mapper.Map<CommentViewModel>(await _commentRepository.GetCommentWithDetailsAsync(id)));
        }

        public async Task<CommentResult> RemoveCommentAsync(int userId, long commentId)
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