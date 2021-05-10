using Ereceipt.Application.ViewModels.Currency;
namespace Ereceipt.Application.Results.Currencies
{
    public class CurrencyResult : Result
    {
        public CurrencyResult(CurrencyViewModel model) : base(model) { }
        public CurrencyResult(CurrencyRootViewModel model) : base(model) { }
        public CurrencyResult(string error) : base(error) { }
    }
}