using AutoMapper;
using Ereceipt.Application.Interfaces;
using Ereceipt.Application.ViewModels.User;
using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using Ereceipt.Infrastructure.Data;
using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserViewModel> CreateUser(UserCreateViewModel model)
        {
            var user = new User
            {
                Name = model.Name,
                Login = model.Login,
                PasswordHash = PasswordManager.GeneratePasswordHash(model.Password),
                CreatedBy = "0",
                Role = "User"
            };
            return _mapper.Map<UserViewModel>(await _userRepository.CreateAsync(user));
        }

        public async Task<UserViewModel> EditUser(UserEditViewModel model)
        {
            var user = await _userRepository.GetByIdAsTrackingAsync(model.UserId);
            if (user == null)
                return null;
            user.Name = model.Name;
            user.UpdatedAt = DateTime.Now;
            user.UpdatedBy = user.Id.ToString();
            return _mapper.Map<UserViewModel>(await _userRepository.UpdateAsync(user));
        }

        public async Task<List<UserViewModel>> GetAllUsers(int afterId)
        {
            return _mapper.Map<List<UserViewModel>>(await _userRepository.GetAllAsync(afterId));
        }

        public async Task<UserViewModel> GetUserById(int id)
        {
            return _mapper.Map<UserViewModel>(await _userRepository.FindAsync(d => d.Id == id));
        }

        public async Task<List<UserViewModel>> SearchUsers(string user, int afterId)
        {
            return _mapper.Map<List<UserViewModel>>(await _userRepository.SearchUsersAsync(user, afterId));
        }
    }
}