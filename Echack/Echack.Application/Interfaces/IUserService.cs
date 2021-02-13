using Echack.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Echack.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> CreateUser(UserCreateViewModel model);
        Task<UserViewModel> EditUser(UserEditViewModel model);
        Task<UserViewModel> GetUserById(int id);
        Task<List<UserViewModel>> SearchUsers(string user, int afterId);
        Task<List<UserViewModel>> GetAllUsers(int afterId);
    }
}