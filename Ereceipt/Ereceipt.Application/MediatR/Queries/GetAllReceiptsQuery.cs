using Ereceipt.Application.Interfaces;
using Ereceipt.Application.ViewModels.Receipt;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Queries
{
    public class GetAllReceiptsQuery : IRequest<List<ReceiptViewModel>>
    {
        public int Skip { get; set; }

        public GetAllReceiptsQuery(int skip)
        {
            Skip = skip;
        }
    }

    public class GetAllReceiptQueryHandler : IRequestHandler<GetAllReceiptsQuery, List<ReceiptViewModel>>
    {
        IReceiptService _ReceiptService;
        public GetAllReceiptQueryHandler(IReceiptService ReceiptService)
        {
            _ReceiptService = ReceiptService;
        }


        public async Task<List<ReceiptViewModel>> Handle(GetAllReceiptsQuery request, CancellationToken cancellationToken)
        {
            return await _ReceiptService.GetAllReceipts(request.Skip);
        }
    }
}