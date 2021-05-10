using Ereceipt.Application.Results;
using Ereceipt.Application.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Queries
{
    public class GetUserReceiptsCountQuery : IRequest<CountResult>
    {
        public int UserId { get; set; }
        public GetUserReceiptsCountQuery(int userId)
        {
            UserId = userId;
        }
    }

    public class GetUserReceiptsCountQueryHandler : IRequestHandler<GetUserReceiptsCountQuery, CountResult>
    {
        IReceiptService _ReceiptService;
        public GetUserReceiptsCountQueryHandler(IReceiptService ReceiptService)
        {
            _ReceiptService = ReceiptService;
        }


        public async Task<CountResult> Handle(GetUserReceiptsCountQuery request, CancellationToken cancellationToken)
        {
            return await _ReceiptService.GetUserReceiptsCountAsync(request.UserId);
        }
    }
}