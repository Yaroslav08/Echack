using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Results.Comments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ereceipt.Application.MediatR.Commands
{
    public class RemoveCommentCommand : IRequest<CommentResult>
    {
        public RemoveCommentCommand(int userId, long commentId)
        {
            UserId = userId;
            CommentId = commentId;
        }

        public int UserId { get; set; }
        public long CommentId { get; set; }
    }

    public class RemoveCommentCommandHandler : IRequestHandler<RemoveCommentCommand, CommentResult>
    {
        ICommentService commentService;

        public RemoveCommentCommandHandler(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public async Task<CommentResult> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {
            return await commentService.RemoveComment(request.UserId, request.CommentId);
        }
    }
}
