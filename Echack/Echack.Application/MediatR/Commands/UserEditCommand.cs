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
    public class UserEditCommand : RequestModel, IRequest<UserViewModel>
    {
        [Required, MinLength(5), MaxLength(150)]
        public string Name { get; set; }
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
            return await _userService.EditUser(new UserEditViewModel
            {
                Name = request.Name,
                UserId = request.UserId
            });
        }
    }
}