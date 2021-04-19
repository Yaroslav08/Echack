using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Results.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Queries
{
    public class SearchUsersQuery : IRequest<ListUsersResult>
    {
        public SearchUsersQuery(string name, int afterId)
        {
            Name = name;
            AfterId = afterId;
        }

        public string Name { get; set; }
        public int AfterId { get; set; }
    }

    public class SearchUsersHandler : IRequestHandler<SearchUsersQuery, ListUsersResult>
    {
        IUserService _userService;
        public SearchUsersHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ListUsersResult> Handle(SearchUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userService.SearchUsersAsync(request.Name, request.AfterId);
        }
    }
}