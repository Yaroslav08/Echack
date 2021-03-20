using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Results.Users;
using Ereceipt.Application.ViewModels.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ereceipt.Application.MediatR.Queries
{
    public class GetAllUsersQuery : IRequest<ListUsersResult>
    {
        public int AvfterId { get; set; }

        public GetAllUsersQuery(int avfterId)
        {
            AvfterId = avfterId;
        }
    }

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ListUsersResult>
    {
        IUserService _userService;
        public GetAllUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<ListUsersResult> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetAllUsers(request.AvfterId);
        }
    }
}
