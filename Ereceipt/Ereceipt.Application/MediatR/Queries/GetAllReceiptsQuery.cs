using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Results.Receipts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Queries
{
    public class GetAllReceiptsQuery : IRequest<ListReceiptResult>
    {
        public int Skip { get; set; }

        public GetAllReceiptsQuery(int skip)
        {
            Skip = skip;
        }
    }

    public class GetAllReceiptQueryHandler : IRequestHandler<GetAllReceiptsQuery, ListReceiptResult>
    {
        IReceiptService _ReceiptService;
        public GetAllReceiptQueryHandler(IReceiptService ReceiptService)
        {
            _ReceiptService = ReceiptService;
        }


        public async Task<ListReceiptResult> Handle(GetAllReceiptsQuery request, CancellationToken cancellationToken)
        {
            return await _ReceiptService.GetAllReceipts(request.Skip);
        }
    }
}