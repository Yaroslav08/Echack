using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.Results.Receipts;
using Ereceipt.Application.ViewModels.Receipt;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class RemoveReceiptFromGroupCommand : IRequest<ReceiptResult>
    {
        public ReceiptGroupCreateModel ToGroup { get; set; }
        public RemoveReceiptFromGroupCommand(ReceiptGroupCreateModel toGroup)
        {
            ToGroup = toGroup;
        }
    }

    public class RemoveReceiptFromGroupCommandHandler : IRequestHandler<RemoveReceiptFromGroupCommand, ReceiptResult>
    {
        private readonly IReceiptService _receiptService;
        public RemoveReceiptFromGroupCommandHandler(IReceiptService ReceiptService)
        {
            _receiptService = ReceiptService;
        }


        public async Task<ReceiptResult> Handle(RemoveReceiptFromGroupCommand request, CancellationToken cancellationToken)
        {
            return await _receiptService.RemoveReceiptFromGroupAsync(request.ToGroup);
        }
    }
}