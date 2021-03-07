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
    public class AddChackToGroupCommand : IRequest<ChackViewModel>
    {
        public ChackGroupCreateModel ToGroup { get; set; }
        public AddChackToGroupCommand(ChackGroupCreateModel toGroup)
        {
            ToGroup = toGroup;
        }
    }

    public class AddChackToGroupCommandHandler : IRequestHandler<AddChackToGroupCommand, ChackViewModel>
    {
        IChackService _chackService;
        public AddChackToGroupCommandHandler(IChackService chackService)
        {
            _chackService = chackService;
        }


        public async Task<ChackViewModel> Handle(AddChackToGroupCommand request, CancellationToken cancellationToken)
        {
            return await _chackService.AddChackToGroup(request.ToGroup);
        }
    }
}