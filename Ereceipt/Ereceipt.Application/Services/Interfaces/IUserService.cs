using Ereceipt.Application.Results.Users;
using Ereceipt.Application.ViewModels.User;
using Ereceipt.Domain.Models;
using System.Threading.Tasks;
namespace Ereceipt.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResult> EditUserAsync(UserEditViewModel model);
        Task<UserResult> GetUserByIdAsync(int id);
        Task<ListUsersResult> SearchUsersAsync(string user, int afterId);
        Task<ListUsersResult> GetAllUsersAsync(int afterId);
    }
}