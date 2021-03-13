using Ereceipt.Application.Interfaces;
using Ereceipt.Application.ViewModels.Receipt;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class AddReceiptToGroupCommand : IRequest<ReceiptViewModel>
    {
        public ReceiptGroupCreateModel ToGroup { get; set; }
        public AddReceiptToGroupCommand(ReceiptGroupCreateModel toGroup)
        {
            ToGroup = toGroup;
        }
    }

    public class AddReceiptToGroupCommandHandler : IRequestHandler<AddReceiptToGroupCommand, ReceiptViewModel>
    {
        IReceiptService _ReceiptService;
        public AddReceiptToGroupCommandHandler(IReceiptService ReceiptService)
        {
            _ReceiptService = ReceiptService;
        }


        public async Task<ReceiptViewModel> Handle(AddReceiptToGroupCommand request, CancellationToken cancellationToken)
        {
            return await _ReceiptService.AddReceiptToGroup(request.ToGroup);
        }
    }
}