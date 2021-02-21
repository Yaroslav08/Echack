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
    public class GetChackByIdQuery : IRequest<ChackViewModel>
    {
        public Guid Id { get; set; }

        public GetChackByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetChackByIdQueryHandler : IRequestHandler<GetChackByIdQuery, ChackViewModel>
    {
        IChackService _chackService;
        public GetChackByIdQueryHandler(IChackService chackService)
        {
            _chackService = chackService;
        }


        public async Task<ChackViewModel> Handle(GetChackByIdQuery request, CancellationToken cancellationToken)
        {
            return await _chackService.GetChack(request.Id);
        }
    }
}