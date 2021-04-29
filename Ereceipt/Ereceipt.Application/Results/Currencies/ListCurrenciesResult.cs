using Ereceipt.Application.ViewModels.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.Results.Currencies
{
    public class ListCurrenciesResult : Result
    {
        public ListCurrenciesResult(List<CurrencyViewModel> models) : base(models) { }
        public ListCurrenciesResult(List<CurrencyRootViewModel> models) : base(models) { }
    }
}