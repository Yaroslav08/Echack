using Ereceipt.Application.Interfaces;
using Ereceipt.Application.ViewModels.Currency;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Ereceipt.Web.Controllers
{
    public class CurrenciesController : ApiController
    {
        public ICurrencyService _currencyService;
        ILogger<CurrenciesController> _logger;
        public CurrenciesController(ICurrencyService currencyService, ILogger<CurrenciesController> logger)
        {
            _currencyService = currencyService;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCurrencies()
        {
            var result = await _currencyService.GetAllCurrenciesAsync();
            return Result(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurrencyById(int id)
        {
            var result = await _currencyService.GetCurrencyByIdAsync(id);
            return Result(result);
        }

        [HttpGet("bycode/{code}")]
        public async Task<IActionResult> GetCurrenciesByCode(string code)
        {
            var result = await _currencyService.GetCurrenciesByCodeAsync(code);
            return Result(result);
        }

        [Authorize(Roles = "SAdmin, Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateCurrency([FromBody] CurrencyCreateModel model)
        {
            model.UserId = GetId();
            model.IP = GetIpAddress();
            var result = await _currencyService.CreateCurrencyAsync(model);
            return Result(result);
        }

        [Authorize(Roles = "SAdmin, Admin")]
        [HttpPut]
        public async Task<IActionResult> EditCurrency([FromBody] CurrencyEditModel model)
        {
            var result = await _currencyService.EditCurrencyAsync(model);
            return Result(result);
        }

        [Authorize(Roles = "SAdmin, Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCurrency(int id)
        {
            var result = await _currencyService.RemoveCurrencyAsync(id);
            return Result(result);
        }
    }
}
