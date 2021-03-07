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
    public class GetUserGroupsQuery : IRequest<List<GroupViewModel>>
    {
        public int Id { get; set; }
        public GetUserGroupsQuery(int id)
        {
            Id = id;
        }
    }

    public class GetUserGroupsQueryHandler : IRequestHandler<GetUserGroupsQuery, List<GroupViewModel>>
    {
        IGroupService _groupService;
        public GetUserGroupsQueryHandler(IGroupService groupService)
        {
            _groupService = groupService;
        }


        public async Task<List<GroupViewModel>> Handle(GetUserGroupsQuery request, CancellationToken cancellationToken)
        {
            return await _groupService.GetGroupsByUserId(request.Id);
        }
    }
}