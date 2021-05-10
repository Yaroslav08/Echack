using System.Threading.Tasks;

namespace Ereceipt.Domain.Interfaces
{
    public interface ITestDataRepository
    {
        Task<string> LoadTestDataAsync(string[] products);
    }
}
