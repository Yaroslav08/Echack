using Ereceipt.Application.ViewModels.Group;
using System.Collections.Generic;

namespace Ereceipt.Application.Results.Groups
{
    public class ListReceiptGroupResult : Result<List<ReceiptGroupViewModel>>
    {
        public ListReceiptGroupResult(List<ReceiptGroupViewModel> receipts) : base(receipts) { }
    }
}
