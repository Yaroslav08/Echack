using Ereceipt.Application.ViewModels.Authentication;
using System.Threading.Tasks;
namespace Ereceipt.Application.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginViewModel> LoginAsync(LoginModel model);
        Task<RegisterViewModel> RegisterAsync(RegisterModel model);
    }
}