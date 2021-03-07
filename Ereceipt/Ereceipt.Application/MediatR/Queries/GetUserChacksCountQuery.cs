using Ereceipt.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Queries
{
    public class GetUserChacksCountQuery : IRequest<int>
    {
        public int UserId { get; set; }
        public GetUserChacksCountQuery(int userId)
        {
            UserId = userId;
        }
    }

    public class GetUserChacksCountQueryHandler : IRequestHandler<GetUserChacksCountQuery, int>
    {
        IChackService _chackService;
        public GetUserChacksCountQueryHandler(IChackService chackService)
        {
            _chackService = chackService;
        }


        public async Task<int> Handle(GetUserChacksCountQuery request, CancellationToken cancellationToken)
        {
            return await _chackService.GetUserChacksCount(request.UserId);
        }
    }
}