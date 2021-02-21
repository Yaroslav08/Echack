using Echack.Application.Interfaces;
using Echack.Application.ViewModels.Chack;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Echack.Web.Controllers
{
    public class ChacksController : BaseController
    {
        private readonly IChackService _chackService;
        public ChacksController(IChackService chackService)
        {
            _chackService = chackService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateChack([FromBody] ChackCreateViewModel model)
        {
            var chack = await _chackService.CreateCheck(model);
            return Ok(chack);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChackById(Guid id)
        {
            var chack = await _chackService.GetChack(id);
            return Ok(chack);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChacks(int skip = 0)
        {
            var chaks = await _chackService.GetAllChacks(skip);
            return Ok(chaks);
        }

    }
}
