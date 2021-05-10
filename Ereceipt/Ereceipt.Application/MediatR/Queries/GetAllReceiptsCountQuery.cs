using Ereceipt.Application.Results;
using Ereceipt.Application.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ereceipt.Application.MediatR.Queries
{
    public class GetAllReceiptsCountQuery : IRequest<CountResult>
    {

    }

    public class GetAllReceiptsCountQueryHandler : IRequestHandler<GetAllReceiptsCountQuery, CountResult>
    {
        IReceiptService _ReceiptService;
        public GetAllReceiptsCountQueryHandler(IReceiptService ReceiptService)
        {
            _ReceiptService = ReceiptService;
        }


        public async Task<CountResult> Handle(GetAllReceiptsCountQuery request, CancellationToken cancellationToken)
        {
            return await _ReceiptService.GetAllReceiptsCountAsync();
        }
    }
}
