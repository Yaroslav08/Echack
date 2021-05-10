using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.Results.Receipts;
using Ereceipt.Application.ViewModels.Receipt;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class ReceiptCreateCommand : IRequest<ReceiptResult>
    {
        public ReceiptCreateModel Receipt { get; set; }

        public ReceiptCreateCommand(ReceiptCreateModel receipt)
        {
            Receipt = receipt;
        }
    }

    public class ReceiptCreateCommandHandler : IRequestHandler<ReceiptCreateCommand, ReceiptResult>
    {
        IReceiptService _ReceiptService;
        public ReceiptCreateCommandHandler(IReceiptService ReceiptService)
        {
            _ReceiptService = ReceiptService;
        }


        public async Task<ReceiptResult> Handle(ReceiptCreateCommand request, CancellationToken cancellationToken)
        {
            return await _ReceiptService.CreateReceiptAsync(request.Receipt);
        }
    }
}