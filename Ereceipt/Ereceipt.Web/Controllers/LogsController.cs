using Ereceipt.Web.Logging;
using Ereceipt.Web.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Ereceipt.Web.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(Roles = "Admin")]
    [AllowAnonymous]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILoggerRepo _rep;
        public LogsController(ILoggerRepo rep)
        {
            _rep = rep;
        }


        [HttpGet]
        public IActionResult GetAllLogs()
        {
            return Ok(new APIOKResponse(_rep.GetAllLogs()));
        }

        [HttpGet("{id}")]
        public IActionResult GetLogById(string id)
        {
            return Ok(new APIOKResponse(_rep.GetLogById(id)));
        }
    }
}