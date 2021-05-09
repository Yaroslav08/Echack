using System.Threading.Tasks;
namespace Ereceipt.Application.Services.Interfaces
{
    public interface ITestDataService
    {
        Task<string> LoadAllTestData();
    }
}