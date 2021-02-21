using Echack.Application.Interfaces;
using Echack.Application.ViewModels;
using Echack.Application.ViewModels.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Echack.Application.MediatR.Commands
{
    public class UserCreateCommand : IRequest<UserViewModel>
    {
        public UserCreateViewModel User { get; set; }

        public UserCreateCommand(UserCreateViewModel user)
        {
            User = user;
        }
    }

    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, UserViewModel>
    {
        IUserService _userService;
        public UserCreateCommandHandler(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<UserViewModel> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            return await _userService.CreateUser(request.User);
        }
    }
}