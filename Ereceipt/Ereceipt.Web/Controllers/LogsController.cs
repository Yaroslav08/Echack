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
        private readonly ILoggerRepository _rep;
        public LogsController(ILoggerRepository rep)
        {
            _rep = rep;
        }

        [HttpGet]
        public IActionResult GetAllLogs()
        {
            var result = _rep.GetAllLogs();
            if (result == null || result.Count == 0)
                return Ok(new APINotFoundResponse());
            return Ok(new APIOKResponse(result));
        }

        [HttpGet("{id}")]
        public IActionResult GetLogById(string id)
        {
            var result = _rep.GetLogById(id);
            if (result != null)
                return Ok(new APIOKResponse(result));
            return Ok(new APINotFoundResponse());
        }

        [HttpGet("1/{id}")]
        public IActionResult GetLogsByUserId(string id)
        {
            var result = _rep.GetAllLogsByUserId(id);
            if (result == null || result.Count == 0)
                return Ok(new APINotFoundResponse());
            return Ok(new APIOKResponse(result));
        }

        [HttpGet("2/{username}")]
        public IActionResult GetLogsByUsername(string username)
        {
            var result = _rep.GetAllLogsByUsername(username);
            if (result == null || result.Count == 0)
                return Ok(new APINotFoundResponse());
            return Ok(new APIOKResponse(result));
        }
    }
}