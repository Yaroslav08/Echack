using Ereceipt.Application.Results.Currencies;
using Ereceipt.Application.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Queries
{
    public class GetAllCurrenciesQuery : IRequest<ListCurrenciesResult> { }

    public class GetAllCurrenciesQueryHandler : IRequestHandler<GetAllCurrenciesQuery, ListCurrenciesResult>
    {
        private readonly ICurrencyService _currencyService;
        public GetAllCurrenciesQueryHandler(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public async Task<ListCurrenciesResult> Handle(GetAllCurrenciesQuery request, CancellationToken cancellationToken)
        {
            return await _currencyService.GetAllCurrenciesAsync();
        }
    }
}