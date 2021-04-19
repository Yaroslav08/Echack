using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Results.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Queries
{
    public class GetUserByIdQuery : IRequest<UserResult>
    {
        public int Id { get; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserResult>
    {
        IUserService _userService;
        public GetUserByIdHandler(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<UserResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserByIdAsync(request.Id);
        }
    }
}
