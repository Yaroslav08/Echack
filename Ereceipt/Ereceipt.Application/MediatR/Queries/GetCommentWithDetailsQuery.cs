using Ereceipt.Application.Results.Comments;
using Ereceipt.Application.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Queries
{
    public class GetCommentWithDetailsQuery : IRequest<CommentResult>
    {
        public long Id { get; set; }

        public GetCommentWithDetailsQuery(long id)
        {
            Id = id;
        }
    }

    public class GetCommentWithDetailsQueryHandler : IRequestHandler<GetCommentWithDetailsQuery, CommentResult>
    {
        ICommentService _commentService;
        public GetCommentWithDetailsQueryHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<CommentResult> Handle(GetCommentWithDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _commentService.GetCommentWithDetailsAsync(request.Id);
        }
    }
}