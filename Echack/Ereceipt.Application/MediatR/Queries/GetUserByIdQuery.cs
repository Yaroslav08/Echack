using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ereceipt.Application.Interfaces;
using Ereceipt.Application.ViewModels.User;
using MediatR;
namespace Ereceipt.Application.MediatR.Queries
{
    public class GetUserByIdQuery : IRequest<UserViewModel>
    {
        public int Id { get; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        IUserService _userService;
        public GetUserByIdHandler(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserById(request.Id);
        }
    }
}
