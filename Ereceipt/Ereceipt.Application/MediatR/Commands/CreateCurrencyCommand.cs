using Ereceipt.Application.Results.Currencies;
using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.Currency;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Commands
{
    public class CreateCurrencyCommand : IRequest<CurrencyResult>
    {
        public CurrencyCreateModel Currency { get; set; }
        public CreateCurrencyCommand(CurrencyCreateModel currency)
        {
            Currency = currency;
        }
    }
    public class CreateCurrencyCommandHandler : IRequestHandler<CreateCurrencyCommand, CurrencyResult>
    {
        private readonly ICurrencyService _currencyService;
        public CreateCurrencyCommandHandler(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }
        public async Task<CurrencyResult> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            return await _currencyService.CreateCurrencyAsync(request.Currency);
        }
    }
}