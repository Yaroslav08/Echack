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
    public class GetAllChackQuery : IRequest<List<ChackViewModel>>
    {
        public int Skip { get; set; }

        public GetAllChackQuery(int skip)
        {
            Skip = skip;
        }
    }

    public class GetAllChackQueryHandler : IRequestHandler<GetAllChackQuery, List<ChackViewModel>>
    {
        IChackService _chackService;
        public GetAllChackQueryHandler(IChackService chackService)
        {
            _chackService = chackService;
        }


        public async Task<List<ChackViewModel>> Handle(GetAllChackQuery request, CancellationToken cancellationToken)
        {
            return await _chackService.GetAllChacks(request.Skip);
        }
    }
}