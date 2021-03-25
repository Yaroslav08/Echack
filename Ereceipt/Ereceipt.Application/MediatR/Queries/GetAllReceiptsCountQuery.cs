using Ereceipt.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ereceipt.Application.MediatR.Queries
{
    public class GetAllReceiptsCountQuery : IRequest<int>
    {

    }

    public class GetAllReceiptsCountQueryHandler : IRequestHandler<GetAllReceiptsCountQuery, int>
    {
        IReceiptService _ReceiptService;
        public GetAllReceiptsCountQueryHandler(IReceiptService ReceiptService)
        {
            _ReceiptService = ReceiptService;
        }


        public async Task<int> Handle(GetAllReceiptsCountQuery request, CancellationToken cancellationToken)
        {
            return await _ReceiptService.GetAllReceiptsCount();
        }
    }
}
