using Ereceipt.Application.Interfaces;
using Ereceipt.Application.ViewModels.Group;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Queries
{
    public class GetChacksByGroupIdQuery : IRequest<List<ChackGroupViewModel>>
    {
        public Guid Id { get; set; }
        public int Skip { get; set; }
        public GetChacksByGroupIdQuery(Guid id, int skip)
        {
            Id = id;
            Skip = skip;
        }
    }

    public class GetChacksByGroupIdQueryHandler : IRequestHandler<GetChacksByGroupIdQuery, List<ChackGroupViewModel>>
    {
        IGroupService _groupService;

        public GetChacksByGroupIdQueryHandler(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public async Task<List<ChackGroupViewModel>> Handle(GetChacksByGroupIdQuery request, CancellationToken cancellationToken)
        {
            return await _groupService.GetChacksByGroupId(request.Id, request.Skip);
        }
    }
}