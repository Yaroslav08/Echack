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
    public class RemoveReceiptCommand : IRequest<ReceiptViewModel>
    {
        public RemoveReceiptCommand(int userId, Guid receiptId)
        {
            UserId = userId;
            ReceiptId = receiptId;
        }

        public int UserId { get; }
        public Guid ReceiptId { get; }
    }

    public class RemoveReceiptCommandHandler : IRequestHandler<RemoveReceiptCommand, ReceiptViewModel>
    {
        IReceiptService _ReceiptService;
        public RemoveReceiptCommandHandler(IReceiptService receiptService)
        {
            _ReceiptService = receiptService;
        }


        public async Task<ReceiptViewModel> Handle(RemoveReceiptCommand request, CancellationToken cancellationToken)
        {
            return await _ReceiptService.RemoveReceipt(request.ReceiptId, request.UserId);
        }
    }
}