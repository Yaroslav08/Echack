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
    public class GetAllChacksCountQuery : IRequest<int>
    {

    }

    public class GetAllChacksCountQueryHandler : IRequestHandler<GetAllChacksCountQuery, int>
    {
        IChackService _chackService;
        public GetAllChacksCountQueryHandler(IChackService chackService)
        {
            _chackService = chackService;
        }


        public async Task<int> Handle(GetAllChacksCountQuery request, CancellationToken cancellationToken)
        {
            return await _chackService.GetAllChacksCount();
        }
    }
}
