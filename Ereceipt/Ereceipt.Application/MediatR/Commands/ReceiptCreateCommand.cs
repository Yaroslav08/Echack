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
    public class ReceiptCreateCommand : IRequest<ReceiptViewModel>
    {
        public ReceiptCreateViewModel Receipt { get; set; }

        public ReceiptCreateCommand(ReceiptCreateViewModel receipt)
        {
            Receipt = receipt;
        }
    }

    public class ReceiptCreateCommandHandler : IRequestHandler<ReceiptCreateCommand, ReceiptViewModel>
    {
        IReceiptService _ReceiptService;
        public ReceiptCreateCommandHandler(IReceiptService ReceiptService)
        {
            _ReceiptService = ReceiptService;
        }


        public async Task<ReceiptViewModel> Handle(ReceiptCreateCommand request, CancellationToken cancellationToken)
        {
            return await _ReceiptService.CreateReceipt(request.Receipt);
        }
    }
}