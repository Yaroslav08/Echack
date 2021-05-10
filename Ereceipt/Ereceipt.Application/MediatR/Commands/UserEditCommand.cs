using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.Results.Users;
using Ereceipt.Application.ViewModels.User;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class UserEditCommand : IRequest<UserResult>
    {
        public UserEditModel User { get; set; }
        public UserEditCommand(UserEditModel user)
        {
            User = user;
        }
    }

    public class UserEditCommandHandler : IRequestHandler<UserEditCommand, UserResult>
    {
        IUserService _userService;
        public UserEditCommandHandler(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<UserResult> Handle(UserEditCommand request, CancellationToken cancellationToken)
        {
            return await _userService.EditUserAsync(request.User);
        }
    }
}