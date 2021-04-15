using Ereceipt.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace Ereceipt.Web.Controllers
{
    public class DatasController : ApiController
    {
        private readonly ITestDataService _testDataService;

        public DatasController(ITestDataService testDataService)
        {
            _testDataService = testDataService;
        }


        [HttpGet("load")]
        public async Task<IActionResult> LoadTestData()
        {
            var res = await _testDataService.LoadAllTestData();
            return ResultOk(res);
        }
    }
}