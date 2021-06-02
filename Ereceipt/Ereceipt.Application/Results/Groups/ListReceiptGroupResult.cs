using Ereceipt.Application.ViewModels.Group;
using System.Collections.Generic;

namespace Ereceipt.Application.Results.Groups
{
    public class ListReceiptGroupResult : Result
    {
        public ListReceiptGroupResult(List<ReceiptGroupViewModel> receipts) : base(receipts) { }
        public ListReceiptGroupResult(string error) : base(error) { }
    }
}
