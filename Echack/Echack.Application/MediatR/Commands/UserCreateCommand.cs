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
    public class UserCreateCommand : RequestModel, IRequest<UserViewModel>
    {
        [Required, MinLength(5), MaxLength(150)]
        public string Name { get; set; }
        [MinLength(8), MaxLength(100)]
        public string Login { get; set; }
        [MinLength(8), MaxLength(25)]
        public string Password { get; set; }
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
            return await _userService.CreateUser(new UserCreateViewModel
            {
                Name = request.Name,
                Login = request.Login,
                Password = request.Password,
                UserId = request.UserId
            });
        }
    }
}