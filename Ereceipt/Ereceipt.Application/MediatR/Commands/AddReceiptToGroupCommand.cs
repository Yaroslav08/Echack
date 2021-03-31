using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Results.Receipts;
using Ereceipt.Application.ViewModels.Receipt;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class AddReceiptToGroupCommand : IRequest<ReceiptResult>
    {
        public ReceiptGroupCreateModel ToGroup { get; set; }
        public AddReceiptToGroupCommand(ReceiptGroupCreateModel toGroup)
        {
            ToGroup = toGroup;
        }
    }

    public class AddReceiptToGroupCommandHandler : IRequestHandler<AddReceiptToGroupCommand, ReceiptResult>
    {
        IReceiptService _ReceiptService;
        public AddReceiptToGroupCommandHandler(IReceiptService ReceiptService)
        {
            _ReceiptService = ReceiptService;
        }


        public async Task<ReceiptResult> Handle(AddReceiptToGroupCommand request, CancellationToken cancellationToken)
        {
            return await _ReceiptService.AddReceiptToGroup(request.ToGroup);
        }
    }
}