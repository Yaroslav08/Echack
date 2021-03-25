using Ereceipt.Application.Interfaces;
using Ereceipt.Application.ViewModels.Receipt;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Queries
{
    public class GetReceiptByIdQuery : IRequest<ReceiptViewModel>
    {
        public Guid Id { get; set; }

        public GetReceiptByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetReceiptByIdQueryHandler : IRequestHandler<GetReceiptByIdQuery, ReceiptViewModel>
    {
        IReceiptService _ReceiptService;
        public GetReceiptByIdQueryHandler(IReceiptService ReceiptService)
        {
            _ReceiptService = ReceiptService;
        }


        public async Task<ReceiptViewModel> Handle(GetReceiptByIdQuery request, CancellationToken cancellationToken)
        {
            return await _ReceiptService.GetReceipt(request.Id);
        }
    }
}