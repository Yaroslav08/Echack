using Ereceipt.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Queries
{
    public class GetUserReceiptsCountQuery : IRequest<int>
    {
        public int UserId { get; set; }
        public GetUserReceiptsCountQuery(int userId)
        {
            UserId = userId;
        }
    }

    public class GetUserReceiptsCountQueryHandler : IRequestHandler<GetUserReceiptsCountQuery, int>
    {
        IReceiptService _ReceiptService;
        public GetUserReceiptsCountQueryHandler(IReceiptService ReceiptService)
        {
            _ReceiptService = ReceiptService;
        }


        public async Task<int> Handle(GetUserReceiptsCountQuery request, CancellationToken cancellationToken)
        {
            return await _ReceiptService.GetUserReceiptsCount(request.UserId);
        }
    }
}