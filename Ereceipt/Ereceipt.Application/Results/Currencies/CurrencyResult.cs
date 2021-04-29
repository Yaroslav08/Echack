using Ereceipt.Application.ViewModels.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.Results.Currencies
{
    public class CurrencyResult : Result
    {
        public CurrencyResult(CurrencyViewModel model) : base(model) { }
        public CurrencyResult(CurrencyRootViewModel model) : base(model) { }
        public CurrencyResult(string error) : base(error) { }
    }
}