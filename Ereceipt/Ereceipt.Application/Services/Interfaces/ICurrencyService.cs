using Ereceipt.Application.Results.Currencies;
using Ereceipt.Application.ViewModels.Currency;
using System.Threading.Tasks;
namespace Ereceipt.Application.Services.Interfaces
{
    public interface ICurrencyService
    {
        Task<ListCurrenciesResult> GetAllCurrenciesAsync();
        Task<ListCurrenciesResult> GetAllCurrenciesRootAsync();
        Task<ListCurrenciesResult> GetCurrenciesByCodeAsync(string code);
        Task<CurrencyResult> GetCurrencyByIdAsync(int id);
        Task<CurrencyResult> CreateCurrencyAsync(CurrencyCreateModel model);
        Task<CurrencyResult> EditCurrencyAsync(CurrencyEditModel model);
        Task<CurrencyResult> RemoveCurrencyAsync(int id);
    }
}