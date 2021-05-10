using Ereceipt.Application.Results.Comments;
using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.Comment;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ereceipt.Application.MediatR.Commands
{
    public class CreateCommentCommand : IRequest<CommentResult>
    {
        public CommentCreateModel Model { get; set; }
        public CreateCommentCommand(CommentCreateModel model)
        {
            Model = model;
        }
    }

    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CommentResult>
    {
        private readonly ICommentService _commentService;
        public CreateCommentCommandHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<CommentResult> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            return await _commentService.CreateCommentAsync(request.Model);
        }
    }
}
