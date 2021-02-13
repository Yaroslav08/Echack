using Echack.Application.Interfaces;
using Echack.Application.ViewModels.Chack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Echack.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<IActionResult> GetChackById(string id)
        {
            var chack = await _chackService.GetChack(Guid.Parse(id));
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
