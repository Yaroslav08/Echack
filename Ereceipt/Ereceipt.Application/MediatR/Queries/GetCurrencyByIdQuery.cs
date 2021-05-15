using Ereceipt.Application.Results.Currencies;
using Ereceipt.Application.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Queries
{
    public class GetCurrencyByIdQuery : IRequest<CurrencyResult>
    {
        public int Id { get; set; }
        public GetCurrencyByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetCurrencyByIdQueryHandler : IRequestHandler<GetCurrencyByIdQuery, CurrencyResult>
    {
        private readonly ICurrencyService _currencyService;
        public GetCurrencyByIdQueryHandler(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public async Task<CurrencyResult> Handle(GetCurrencyByIdQuery request, CancellationToken cancellationToken)
        {
            return await _currencyService.GetCurrencyByIdAsync(request.Id);
        }
    }
}