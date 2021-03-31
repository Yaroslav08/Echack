using Ereceipt.Application.ViewModels.Receipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.Results.Receipts
{
    public class ReceiptResult : Result<ReceiptViewModel>
    {
        public ReceiptResult(ReceiptViewModel receipt) : base(receipt) { }
        public ReceiptResult(string error) : base(error){}
    }
}