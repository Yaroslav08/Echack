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
    public class GetGroupByIdQuery : IRequest<GroupViewModel>
    {
        public Guid Id { get; set; }
        public GetGroupByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetGroupByIdQueryHandler : IRequestHandler<GetGroupByIdQuery, GroupViewModel>
    {
        IGroupService _groupService;

        public GetGroupByIdQueryHandler(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public async Task<GroupViewModel> Handle(GetGroupByIdQuery request, CancellationToken cancellationToken)
        {
            return await _groupService.GetGroupById(request.Id);
        }
    }
}