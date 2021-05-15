using Ereceipt.Application.Results.Currencies;
using Ereceipt.Application.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ereceipt.Application.MediatR.Commands
{
    public class RemoveCurrencyCommand : IRequest<CurrencyResult>
    {
        public int Id { get; set; }
        public RemoveCurrencyCommand(int id)
        {
            Id = id;
        }
    }

    public class RemoveCurrencyCommandHandler : IRequestHandler<RemoveCurrencyCommand, CurrencyResult>
    {
        private readonly ICurrencyService _currencyService;
        public RemoveCurrencyCommandHandler(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public async Task<CurrencyResult> Handle(RemoveCurrencyCommand request, CancellationToken cancellationToken)
        {
            return await _currencyService.RemoveCurrencyAsync(request.Id);
        }
    }
}