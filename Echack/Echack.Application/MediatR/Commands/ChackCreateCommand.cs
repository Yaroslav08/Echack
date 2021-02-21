using Echack.Application.Interfaces;
using Echack.Application.ViewModels.Chack;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Echack.Application.MediatR.Commands
{
    public class ChackCreateCommand : IRequest<ChackViewModel>
    {
        public ChackCreateViewModel Chack { get; set; }

        public ChackCreateCommand(ChackCreateViewModel chack)
        {
            Chack = chack;
        }
    }

    public class ChackCreateCommandHandler : IRequestHandler<ChackCreateCommand, ChackViewModel>
    {
        IChackService _chackService;
        public ChackCreateCommandHandler(IChackService chackService)
        {
            _chackService = chackService;
        }


        public async Task<ChackViewModel> Handle(ChackCreateCommand request, CancellationToken cancellationToken)
        {
            return await _chackService.CreateCheck(request.Chack);
        }
    }
}