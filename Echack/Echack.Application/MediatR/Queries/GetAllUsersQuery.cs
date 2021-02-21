using Echack.Application.Interfaces;
using Echack.Application.ViewModels.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Echack.Application.MediatR.Queries
{
    public class GetAllUsersQuery : IRequest<List<UserViewModel>>
    {
        public int AvfterId { get; set; }

        public GetAllUsersQuery(int avfterId)
        {
            AvfterId = avfterId;
        }
    }

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
    {
        IUserService _userService;
        public GetAllUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetAllUsers(request.AvfterId);
        }
    }
}
