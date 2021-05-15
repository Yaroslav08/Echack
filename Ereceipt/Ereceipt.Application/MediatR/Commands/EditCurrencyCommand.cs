using Ereceipt.Application.Results.Currencies;
using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.Currency;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ereceipt.Application.MediatR.Commands
{
    public class EditCurrencyCommand : IRequest<CurrencyResult>
    {
        public CurrencyEditModel Currency { get; set; }
        public EditCurrencyCommand(CurrencyEditModel currency)
        {
            Currency = currency;
        }
    }

    public class EditCurrencyCommandHandler : IRequestHandler<EditCurrencyCommand, CurrencyResult>
    {
        private readonly ICurrencyService _currencyService;
        public EditCurrencyCommandHandler(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }
        public async Task<CurrencyResult> Handle(EditCurrencyCommand request, CancellationToken cancellationToken)
        {
            return await _currencyService.EditCurrencyAsync(request.Currency);
        }
    }
}
