using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Results.Receipts;
using Ereceipt.Application.ViewModels.Receipt;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ereceipt.Application.MediatR.Queries
{
    public class GetMyReceiptsQuery : IRequest<ListReceiptResult>
    {
        public int UserId { get; set; }
        public int Skip { get; set; }
        public GetMyReceiptsQuery(int userId, int skip)
        {
            UserId = userId;
            Skip = skip;
        }
    }

    public class GetMyReceiptsQueryHandler : IRequestHandler<GetMyReceiptsQuery, ListReceiptResult>
    {
        IReceiptService _ReceiptService;
        public GetMyReceiptsQueryHandler(IReceiptService ReceiptService)
        {
            _ReceiptService = ReceiptService;
        }

        public async Task<ListReceiptResult> Handle(GetMyReceiptsQuery request, CancellationToken cancellationToken)
        {
            return await _ReceiptService.GetUserReceiptsByUserIdAsync(request.UserId, request.Skip);
        }
    }
}
