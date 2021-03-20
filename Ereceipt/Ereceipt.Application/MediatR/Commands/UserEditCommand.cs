using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Results.Users;
using Ereceipt.Application.ViewModels;
using Ereceipt.Application.ViewModels.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class UserEditCommand : IRequest<UserResult>
    {
        public UserEditViewModel User { get; set; }
        public UserEditCommand(UserEditViewModel user)
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
            return await _userService.EditUser(request.User);
        }
    }
}