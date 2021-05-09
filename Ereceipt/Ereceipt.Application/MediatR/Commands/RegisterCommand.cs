using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.Authentication;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ereceipt.Application.MediatR.Commands
{
    public class RegisterCommand : IRequest<RegisterViewModel>
    {
        public RegisterModel User { get; set; }

        public RegisterCommand(RegisterModel user)
        {
            User = user;
        }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterViewModel>
    {
        private readonly IAuthenticationService _authenticationService;
        public RegisterCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        public async Task<RegisterViewModel> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _authenticationService.RegisterAsync(request.User);
        }
    }
}