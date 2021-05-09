﻿using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.Results.Users;
using Ereceipt.Application.ViewModels.User;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class UserCreateCommand : IRequest<UserResult>
    {
        public UserCreateViewModel User { get; set; }

        public UserCreateCommand(UserCreateViewModel user)
        {
            User = user;
        }
    }

    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, UserResult>
    {
        IUserService _userService;
        public UserCreateCommandHandler(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<UserResult> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            return await _userService.CreateUserAsync(request.User);
        }
    }
}