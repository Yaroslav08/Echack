using Ereceipt.Application.Interfaces;
using Ereceipt.Application.ViewModels.Chack;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ereceipt.Application.MediatR.Queries
{
    public class GetMyChacksQuery : IRequest<List<ChackViewModel>>
    {
        public int UserId { get; set; }
        public int Skip { get; set; }
        public GetMyChacksQuery(int userId, int skip)
        {
            UserId = userId;
            Skip = skip;
        }
    }

    public class GetMyChacksQueryHandler : IRequestHandler<GetMyChacksQuery, List<ChackViewModel>>
    {
        IChackService _chackService;
        public GetMyChacksQueryHandler(IChackService chackService)
        {
            _chackService = chackService;
        }

        public async Task<List<ChackViewModel>> Handle(GetMyChacksQuery request, CancellationToken cancellationToken)
        {
            return await _chackService.GetUserChacksByUserId(request.UserId, request.Skip);
        }
    }
}
