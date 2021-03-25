using AutoMapper;
using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Results.Users;
using Ereceipt.Application.ViewModels.User;
using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using Extensions;
using System;
using System.Collections.Generic;
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

        public async Task<UserResult> CreateUser(UserCreateViewModel model)
        {
            var user = new User
            {
                Name = model.Name,
                Login = model.Login,
                PasswordHash = PasswordManager.GeneratePasswordHash(model.Password),
                CreatedBy = "0",
                Role = "User"
            };
            return new UserResult(_mapper.Map<UserViewModel>(await _userRepository.CreateAsync(user)));
        }

        public async Task<UserResult> EditUser(UserEditViewModel model)
        {
            var user = await _userRepository.GetByIdAsTrackingAsync(model.UserId);
            if (user == null)
                return null;
            user.Name = model.Name;
            user.UpdatedAt = DateTime.UtcNow;
            user.UpdatedBy = user.Id.ToString();
            return new UserResult(_mapper.Map<UserViewModel>(await _userRepository.UpdateAsync(user)));
        }

        public async Task<ListUsersResult> GetAllUsers(int afterId)
        {
            return new ListUsersResult(_mapper.Map<List<UserViewModel>>(await _userRepository.GetAllAsync(afterId)));
        }

        public async Task<UserResult> GetUserById(int id)
        {
            return new UserResult(_mapper.Map<UserViewModel>(await _userRepository.FindAsync(d => d.Id == id)));
        }

        public async Task<User> LoginUser(UserLoginViewModel model)
        {
            var user = await _userRepository.FindAsync(d => d.Login == model.Login);
            if (user == null)
                return null;
            if(!PasswordManager.VerifyPasswordHash(model.Password, user.PasswordHash))
            {
                return null;
            }
            return user;
        }

        public async Task<ListUsersResult> SearchUsers(string user, int afterId)
        {
            return new ListUsersResult(_mapper.Map<List<UserViewModel>>(await _userRepository.SearchUsersAsync(user, afterId)));
        }
    }
}