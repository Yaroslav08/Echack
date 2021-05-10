using Ereceipt.Application.Results.Comments;
using Ereceipt.Application.Services.Interfaces;
using MediatR;
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
            return await commentService.RemoveCommentAsync(request.UserId, request.CommentId);
        }
    }
}
