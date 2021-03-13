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
    public class RemoveReceiptFromGroupCommand : IRequest<ReceiptViewModel>
    {
        public ReceiptGroupCreateModel ToGroup { get; set; }
        public RemoveReceiptFromGroupCommand(ReceiptGroupCreateModel toGroup)
        {
            ToGroup = toGroup;
        }
    }

    public class RemoveReceiptFromGroupCommandHandler : IRequestHandler<RemoveReceiptFromGroupCommand, ReceiptViewModel>
    {
        IReceiptService _ReceiptService;
        public RemoveReceiptFromGroupCommandHandler(IReceiptService ReceiptService)
        {
            _ReceiptService = ReceiptService;
        }


        public async Task<ReceiptViewModel> Handle(RemoveReceiptFromGroupCommand request, CancellationToken cancellationToken)
        {
            return await _ReceiptService.RemoveReceiptFromGroup(request.ToGroup);
        }
    }
}