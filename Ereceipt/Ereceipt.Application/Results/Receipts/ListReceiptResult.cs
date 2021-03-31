using Ereceipt.Application.ViewModels.Receipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.Results.Receipts
{
    public class ListReceiptResult : Result<List<ReceiptViewModel>>
    {
        public ListReceiptResult(List<ReceiptViewModel> receipts) : base(receipts) { }
    }
}