using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.Results.Receipts;
using Ereceipt.Application.ViewModels.Receipt;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class CreateReceiptCommand : IRequest<ReceiptResult>
    {
        public ReceiptCreateModel Receipt { get; set; }

        public CreateReceiptCommand(ReceiptCreateModel receipt)
        {
            Receipt = receipt;
        }
    }

    public class ReceiptCreateCommandHandler : IRequestHandler<CreateReceiptCommand, ReceiptResult>
    {
        IReceiptService _ReceiptService;
        public ReceiptCreateCommandHandler(IReceiptService ReceiptService)
        {
            _ReceiptService = ReceiptService;
        }


        public async Task<ReceiptResult> Handle(CreateReceiptCommand request, CancellationToken cancellationToken)
        {
            return await _ReceiptService.CreateReceiptAsync(request.Receipt);
        }
    }
}