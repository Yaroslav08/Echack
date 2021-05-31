using Ereceipt.Application.Results.Receipts;
using Ereceipt.Application.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ereceipt.Application.MediatR.Queries
{
    public class GetReceiptsByShopNameQuery : IRequest<ListReceiptResult>
    {
        public GetReceiptsByShopNameQuery(int userId, string shopName, int skip)
        {
            UserId = userId;
            ShopName = shopName;
            Skip = skip;
        }
        public int UserId { get; set; }
        public string ShopName { get; set; }
        public int Skip { get; set; }
    }

    public class GetReceiptsByShopNameQueryHandler : IRequestHandler<GetReceiptsByShopNameQuery, ListReceiptResult>
    {
        private readonly IReceiptService _receiptService;

        public GetReceiptsByShopNameQueryHandler(IReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        public async Task<ListReceiptResult> Handle(GetReceiptsByShopNameQuery request, CancellationToken cancellationToken)
        {
            return await _receiptService.GetReceiptsByShopNameAsync(request.UserId, request.ShopName, request.Skip);
        }
    }
}