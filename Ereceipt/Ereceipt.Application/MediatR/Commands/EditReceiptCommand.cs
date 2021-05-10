using Ereceipt.Application.Results.Receipts;
using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.Receipt;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class EditReceiptCommand : IRequest<ReceiptResult>
    {
        public ReceiptEditModel Receipt { get; set; }

        public EditReceiptCommand(ReceiptEditModel receipt)
        {
            Receipt = receipt;
        }
    }

    public class ReceiptEditCommandHandler : IRequestHandler<EditReceiptCommand, ReceiptResult>
    {
        IReceiptService _ReceiptService;
        public ReceiptEditCommandHandler(IReceiptService receiptService)
        {
            _ReceiptService = receiptService;
        }


        public async Task<ReceiptResult> Handle(EditReceiptCommand request, CancellationToken cancellationToken)
        {
            return await _ReceiptService.EditReceiptAsync(request.Receipt);
        }
    }
}