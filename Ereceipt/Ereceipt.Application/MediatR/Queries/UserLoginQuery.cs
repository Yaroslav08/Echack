using Ereceipt.Application.Interfaces;
using Ereceipt.Application.ViewModels.User;
using Ereceipt.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Queries
{
    public class UserLoginQuery : IRequest<User>
    {
        public UserLoginViewModel Login { get; set; }
        public UserLoginQuery(UserLoginViewModel login)
        {
            Login = login;
        }
    }

    public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, User>
    {
        IUserService _userService;
        public UserLoginQueryHandler(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<User> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {
            return await _userService.LoginUser(request.Login);
        }
    }
}