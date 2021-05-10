using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.Results.Users;
using MediatR;
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
        private readonly IUserService _userService;
        public GetAllUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<ListUsersResult> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetAllUsersAsync(request.AvfterId);
        }
    }
}
