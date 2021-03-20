using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Results.Groups;
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
    public class GetUserGroupsQuery : IRequest<ListGroupResult>
    {
        public int Id { get; set; }
        public GetUserGroupsQuery(int id)
        {
            Id = id;
        }
    }

    public class GetUserGroupsQueryHandler : IRequestHandler<GetUserGroupsQuery, ListGroupResult>
    {
        IGroupService _groupService;
        public GetUserGroupsQueryHandler(IGroupService groupService)
        {
            _groupService = groupService;
        }


        public async Task<ListGroupResult> Handle(GetUserGroupsQuery request, CancellationToken cancellationToken)
        {
            return await _groupService.GetGroupsByUserId(request.Id);
        }
    }
}