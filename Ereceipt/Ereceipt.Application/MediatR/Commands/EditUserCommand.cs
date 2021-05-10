using Ereceipt.Application.Results.Users;
using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.User;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class EditUserCommand : IRequest<UserResult>
    {
        public UserEditModel User { get; set; }
        public EditUserCommand(UserEditModel user)
        {
            User = user;
        }
    }

    public class UserEditCommandHandler : IRequestHandler<EditUserCommand, UserResult>
    {
        IUserService _userService;
        public UserEditCommandHandler(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<UserResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.EditUserAsync(request.User);
        }
    }
}