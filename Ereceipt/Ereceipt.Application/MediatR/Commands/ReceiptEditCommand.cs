using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.Results.Receipts;
using Ereceipt.Application.ViewModels.Receipt;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class ReceiptEditCommand : IRequest<ReceiptResult>
    {
        public ReceiptEditModel Receipt { get; set; }

        public ReceiptEditCommand(ReceiptEditModel receipt)
        {
            Receipt = receipt;
        }
    }

    public class ReceiptEditCommandHandler : IRequestHandler<ReceiptEditCommand, ReceiptResult>
    {
        IReceiptService _ReceiptService;
        public ReceiptEditCommandHandler(IReceiptService receiptService)
        {
            _ReceiptService = receiptService;
        }


        public async Task<ReceiptResult> Handle(ReceiptEditCommand request, CancellationToken cancellationToken)
        {
            return await _ReceiptService.EditReceiptAsync(request.Receipt);
        }
    }
}