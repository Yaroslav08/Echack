using Ereceipt.Application.ViewModels.Receipt;
using System.Collections.Generic;
namespace Ereceipt.Application.Results.Receipts
{
    public class ListReceiptResult : Result
    {
        public ListReceiptResult(List<ReceiptViewModel> receipts) : base(receipts) { }
    }
}