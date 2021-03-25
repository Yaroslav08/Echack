using Ereceipt.Application.Results.Users;
using Ereceipt.Application.ViewModels.User;
using Ereceipt.Domain.Models;
using System.Threading.Tasks;
namespace Ereceipt.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> LoginUser(UserLoginViewModel model);
        Task<UserResult> CreateUser(UserCreateViewModel model);
        Task<UserResult> EditUser(UserEditViewModel model);
        Task<UserResult> GetUserById(int id);
        Task<ListUsersResult> SearchUsers(string user, int afterId);
        Task<ListUsersResult> GetAllUsers(int afterId);
    }
}