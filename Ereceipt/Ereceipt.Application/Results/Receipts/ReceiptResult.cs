using Ereceipt.Application.ViewModels.Receipt;
namespace Ereceipt.Application.Results.Receipts
{
    public class ReceiptResult : Result
    {
        public ReceiptResult(ReceiptViewModel receipt) : base(receipt) { }
        public ReceiptResult(string error) : base(error){}
    }
}