using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.Authentication;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class LoginCommand : IRequest<LoginViewModel>
    {
        public LoginModel Login { get; set; }
        public LoginCommand(LoginModel login)
        {
            Login = login;
        }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginViewModel>
    {
        private readonly IAuthenticationService _authenticationService;
        public LoginCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        public async Task<LoginViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _authenticationService.LoginAsync(request.Login);
        }
    }
}