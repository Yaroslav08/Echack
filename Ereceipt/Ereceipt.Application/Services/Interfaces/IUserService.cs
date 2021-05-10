using Ereceipt.Application.Results.Users;
using Ereceipt.Application.ViewModels.User;
using System.Threading.Tasks;
namespace Ereceipt.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResult> EditUserAsync(UserEditModel model);
        Task<UserResult> GetUserByIdAsync(int id);
        Task<ListUsersResult> SearchUsersAsync(string user, int afterId);
        Task<ListUsersResult> GetAllUsersAsync(int afterId);
    }
}