using Ereceipt.Application.Extensions;
using Ereceipt.Application.MediatR.Commands;
using Ereceipt.Application.MediatR.Queries;
using Ereceipt.Application.ViewModels.Currency;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ereceipt.Web.Controllers.V1
{
    public class CurrenciesController : ApiController
    {
        private readonly IMediator _mediator;

        public CurrenciesController(IMediator mediator) => _mediator = mediator;


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCurrencies()
        {
            var result = await _mediator.Send(new GetAllCurrenciesQuery());
            return Result(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurrencyById(int id)
        {
            var result = await _mediator.Send(new GetCurrencyByIdQuery(id));
            return Result(result);
        }

        [HttpGet("by-code/{code}")]
        public async Task<IActionResult> GetCurrenciesByCode(string code)
        {
            var result = await _mediator.Send(new GetCurrenciesByCodeQuery(code));
            return Result(result);
        }

        [Authorize(Roles = "SAdmin, Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateCurrency([FromBody] CurrencyCreateModel model)
        {
            model.IncomeRequestInit(GetId(), GetIpAddress());
            var result = await _mediator.Send(new CreateCurrencyCommand(model));
            return Result(result);
        }

        [Authorize(Roles = "SAdmin, Admin")]
        [HttpPut]
        public async Task<IActionResult> EditCurrency([FromBody] CurrencyEditModel model)
        {
            model.IncomeRequestInit(GetId(), GetIpAddress());
            var result = await _mediator.Send(new EditCurrencyCommand(model));
            return Result(result);
        }

        [Authorize(Roles = "SAdmin, Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCurrency(int id)
        {
            var result = await _mediator.Send(new RemoveCurrencyCommand(id));
            return Result(result);
        }
    }
}