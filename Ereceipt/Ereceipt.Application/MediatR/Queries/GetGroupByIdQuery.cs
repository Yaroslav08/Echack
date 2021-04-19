using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Results.Groups;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Queries
{
    public class GetGroupByIdQuery : IRequest<GroupResult>
    {
        public Guid Id { get; set; }
        public GetGroupByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetGroupByIdQueryHandler : IRequestHandler<GetGroupByIdQuery, GroupResult>
    {
        IGroupService _groupService;

        public GetGroupByIdQueryHandler(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public async Task<GroupResult> Handle(GetGroupByIdQuery request, CancellationToken cancellationToken)
        {
            return await _groupService.GetGroupByIdAsync(request.Id);
        }
    }
}