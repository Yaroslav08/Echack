using Ereceipt.Application.Results;
using Ereceipt.Application.ViewModels.User;
using Ereceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> LoginUser(UserLoginViewModel model);
        Task<UserVMResult> CreateUser(UserCreateViewModel model);
        Task<UserVMResult> EditUser(UserEditViewModel model);
        Task<UserVMResult> GetUserById(int id);
        Task<ListUsersVMResult> SearchUsers(string user, int afterId);
        Task<ListUsersVMResult> GetAllUsers(int afterId);
    }
}