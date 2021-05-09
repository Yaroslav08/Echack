using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.Authentication;
using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using Extensions;
using System;
using System.Threading.Tasks;

namespace Ereceipt.Application.Services.Implementations
{
    public class TokenAuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUsernameService _usernameService;
        public TokenAuthenticationService(IUserRepository userRepository, IUsernameService usernameService)
        {
            _userRepository = userRepository;
            _usernameService = usernameService;
        }

        public async Task<LoginViewModel> LoginAsync(LoginModel model)
        {
            var userForLogin = await _userRepository.FindAsync(x => x.Login == model.Login);
            if (userForLogin is null)
                return new LoginViewModel("User with this email not found");
            if (!PasswordManager.VerifyPasswordHash(model.Password, userForLogin.PasswordHash))
                return new LoginViewModel("Password is incorrect");
            return new LoginViewModel(userForLogin.Id, userForLogin.Name, userForLogin.Role, userForLogin.Avatar);
        }

        public async Task<RegisterViewModel> RegisterAsync(RegisterModel model)
        {
            if (await _userRepository.IsExistAsync(x => x.Login == model.Login))
                return new RegisterViewModel("This login is already busy");
            var newUser = new User
            {
                Name = model.Name,
                Avatar = model.Photo,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "0",
                Login = model.Login,
                Role = "User",
                Username = await _usernameService.GeneratingNewUsernameAsync(),
                PasswordHash = PasswordManager.GeneratePasswordHash(model.Password)
            };
            var createdUser = await _userRepository.CreateAsync(newUser);
            if (createdUser is null)
                return new RegisterViewModel("User can`t create");
            return new RegisterViewModel();
        }
    }
}