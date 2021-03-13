using Ereceipt.Application.Interfaces;
using Ereceipt.Application.ViewModels.Receipt;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ereceipt.Application.MediatR.Queries
{
    public class GetMyReceiptsQuery : IRequest<List<ReceiptViewModel>>
    {
        public int UserId { get; set; }
        public int Skip { get; set; }
        public GetMyReceiptsQuery(int userId, int skip)
        {
            UserId = userId;
            Skip = skip;
        }
    }

    public class GetMyReceiptsQueryHandler : IRequestHandler<GetMyReceiptsQuery, List<ReceiptViewModel>>
    {
        IReceiptService _ReceiptService;
        public GetMyReceiptsQueryHandler(IReceiptService ReceiptService)
        {
            _ReceiptService = ReceiptService;
        }

        public async Task<List<ReceiptViewModel>> Handle(GetMyReceiptsQuery request, CancellationToken cancellationToken)
        {
            return await _ReceiptService.GetUserReceiptsByUserId(request.UserId, request.Skip);
        }
    }
}
