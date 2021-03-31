using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Results.Comments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ereceipt.Application.MediatR.Queries
{
    public class GetCommentsOfReceiptQuery : IRequest<ListCommentResult>
    {
        public Guid Id { get; set; }

        public GetCommentsOfReceiptQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetCommentsOfReceiptQueryHandler : IRequestHandler<GetCommentsOfReceiptQuery, ListCommentResult>
    {
        ICommentService _commentService;
        public GetCommentsOfReceiptQueryHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }


        public async Task<ListCommentResult> Handle(GetCommentsOfReceiptQuery request, CancellationToken cancellationToken)
        {
            return await _commentService.GetCommentsByReceiptId(request.Id);
        }
    }
}
