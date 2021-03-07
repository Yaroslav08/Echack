using Ereceipt.Application.Interfaces;
using Ereceipt.Application.ViewModels.Chack;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class RemoveChackFromGroupCommand : IRequest<ChackViewModel>
    {
        public ChackGroupCreateModel ToGroup { get; set; }
        public RemoveChackFromGroupCommand(ChackGroupCreateModel toGroup)
        {
            ToGroup = toGroup;
        }
    }

    public class RemoveChackFromGroupCommandHandler : IRequestHandler<RemoveChackFromGroupCommand, ChackViewModel>
    {
        IChackService _chackService;
        public RemoveChackFromGroupCommandHandler(IChackService chackService)
        {
            _chackService = chackService;
        }


        public async Task<ChackViewModel> Handle(RemoveChackFromGroupCommand request, CancellationToken cancellationToken)
        {
            return await _chackService.RemoveChackFromGroup(request.ToGroup);
        }
    }
}