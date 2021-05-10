using Ereceipt.Application.ViewModels.Currency;
using System.Collections.Generic;
namespace Ereceipt.Application.Results.Currencies
{
    public class ListCurrenciesResult : Result
    {
        public ListCurrenciesResult(List<CurrencyViewModel> models) : base(models) { }
        public ListCurrenciesResult(List<CurrencyRootViewModel> models) : base(models) { }
    }
}