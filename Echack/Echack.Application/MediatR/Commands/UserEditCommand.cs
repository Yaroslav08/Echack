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
    public class UserEditCommand : IRequest<UserViewModel>
    {
        public UserEditViewModel User { get; set; }
        public UserEditCommand(UserEditViewModel user)
        {
            User = user;
        }
    }

    public class UserEditCommandHandler : IRequestHandler<UserEditCommand, UserViewModel>
    {
        IUserService _userService;
        public UserEditCommandHandler(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<UserViewModel> Handle(UserEditCommand request, CancellationToken cancellationToken)
        {
            return await _userService.EditUser(request.User);
        }
    }
}