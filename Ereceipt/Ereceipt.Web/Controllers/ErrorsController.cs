using Ereceipt.Web.AppSetting.Errors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace Ereceipt.Web.Controllers
{
    public class ErrorsController : ApiController
    {
        private readonly IErrorStorage _errorStorage;
        public ErrorsController(IErrorStorage errorStorage)
        {
            _errorStorage = errorStorage;
        }

        [HttpGet]
        public IActionResult GetAllErrors()
        {
            return Ok(_errorStorage.GetAllErrors());
        }

        [HttpGet("{id}")]
        public IActionResult GetErrorById(string id)
        {
            return Ok(_errorStorage.GetErrorById(id));
        }

        [HttpGet("by-code/{code}")]
        public IActionResult GetErrorByCode(string code)
        {
            return Ok(_errorStorage.GetErrorByCode(code));
        }

        [HttpGet("by-category/{category}")]
        public IActionResult GetErrorsByCategory(string category)
        {
            return Ok(_errorStorage.GetErrorsByCategory(category));
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewError([FromBody] ErrorViewModel error)
        {
            _errorStorage.AddNewError(error);
            await _errorStorage.UploadErrorsAsync();
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateError([FromBody] ErrorViewModel error)
        {
            _errorStorage.UpdateError(error);
            return NoContent();
        }
    }
}