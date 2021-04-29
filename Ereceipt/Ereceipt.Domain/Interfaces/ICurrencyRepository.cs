using Ereceipt.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ereceipt.Domain.Interfaces
{
    public interface ICurrencyRepository : IRepository<Currency>
    {
        Task<List<Currency>> GetAllCurrenciesAsync();
        Task<List<Currency>> GetByCodeAsync(string code);
    }
}