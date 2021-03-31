using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Results.Comments;
using Ereceipt.Application.ViewModels.Comment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class EditCommentCommand : IRequest<CommentResult>
    {
        public CommentEditViewModel Model { get; set; }

        public EditCommentCommand(CommentEditViewModel model)
        {
            Model = model;
        }
    }

    public class EditCommentCommandHandler : IRequestHandler<EditCommentCommand, CommentResult>
    {
        ICommentService _commentService;

        public EditCommentCommandHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<CommentResult> Handle(EditCommentCommand request, CancellationToken cancellationToken)
        {
            return await _commentService.EditComment(request.Model);
        }
    }
}