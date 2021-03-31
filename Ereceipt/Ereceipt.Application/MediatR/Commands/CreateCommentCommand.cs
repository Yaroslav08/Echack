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
    public class CreateCommentCommand : IRequest<CommentResult>
    {
        public CommentCreateViewModel Model { get; set; }
        public CreateCommentCommand(CommentCreateViewModel model)
        {
            Model = model;
        }
    }

    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CommentResult>
    {
        ICommentService _commentService;
        public CreateCommentCommandHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<CommentResult> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            return await _commentService.CreateComment(request.Model);
        }
    }
}
