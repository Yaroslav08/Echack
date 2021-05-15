using Ereceipt.Application.Results.Currencies;
using Ereceipt.Application.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Queries
{
    public class GetCurrenciesByCodeQuery : IRequest<ListCurrenciesResult>
    {
        public string Code { get; set; }

        public GetCurrenciesByCodeQuery(string code)
        {
            Code = code;
        }
    }

    public class GetCurrenciesByCodeQueryHandler : IRequestHandler<GetCurrenciesByCodeQuery, ListCurrenciesResult>
    {
        private readonly ICurrencyService _currencyService;
        public GetCurrenciesByCodeQueryHandler(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public async Task<ListCurrenciesResult> Handle(GetCurrenciesByCodeQuery request, CancellationToken cancellationToken)
        {
            return await _currencyService.GetCurrenciesByCodeAsync(request.Code);
        }
    }
}