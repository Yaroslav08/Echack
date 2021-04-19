using Ereceipt.Application.Interfaces;
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
        IReceiptService _ReceiptService;
        public RemoveReceiptFromGroupCommandHandler(IReceiptService ReceiptService)
        {
            _ReceiptService = ReceiptService;
        }


        public async Task<ReceiptResult> Handle(RemoveReceiptFromGroupCommand request, CancellationToken cancellationToken)
        {
            return await _ReceiptService.RemoveReceiptFromGroupAsync(request.ToGroup);
        }
    }
}