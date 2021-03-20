using Ereceipt.Application.ViewModels.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereceipt.Application.Results.Groups
{
    public class ListReceiptGroupResult : Result<List<ReceiptGroupViewModel>>
    {
        public ListReceiptGroupResult(List<ReceiptGroupViewModel> receipts) : base(receipts) { }
    }
}
