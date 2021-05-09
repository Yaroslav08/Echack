using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.Results.Receipts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Queries
{
    public class GetReceiptByIdQuery : IRequest<ReceiptResult>
    {
        public Guid Id { get; set; }

        public GetReceiptByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetReceiptByIdQueryHandler : IRequestHandler<GetReceiptByIdQuery, ReceiptResult>
    {
        IReceiptService _ReceiptService;
        public GetReceiptByIdQueryHandler(IReceiptService ReceiptService)
        {
            _ReceiptService = ReceiptService;
        }


        public async Task<ReceiptResult> Handle(GetReceiptByIdQuery request, CancellationToken cancellationToken)
        {
            return await _ReceiptService.GetReceiptAsync(request.Id);
        }
    }
}