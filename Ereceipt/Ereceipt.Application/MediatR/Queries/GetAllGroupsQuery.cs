using Ereceipt.Application.Results.Groups;
using Ereceipt.Application.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Queries
{
    public class GetAllGroupsQuery : IRequest<ListGroupResult>
    {
        public int Skip { get; set; }

        public GetAllGroupsQuery(int skip)
        {
            Skip = skip;
        }
    }

    public class GetAllGroupsQueryHandler : IRequestHandler<GetAllGroupsQuery, ListGroupResult>
    {
        IGroupService _groupService;
        public GetAllGroupsQueryHandler(IGroupService groupService)
        {
            _groupService = groupService;
        }


        public async Task<ListGroupResult> Handle(GetAllGroupsQuery request, CancellationToken cancellationToken)
        {
            return await _groupService.GetAllGroupsAsync(request.Skip);
        }
    }
}