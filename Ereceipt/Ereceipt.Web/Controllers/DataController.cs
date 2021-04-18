using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Results;
using Ereceipt.Application.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Ereceipt.Web.Controllers
{
    public class DataController : ApiController
    {
        private readonly ITestDataService _testDataService;

        public DataController(ITestDataService testDataService)
        {
            _testDataService = testDataService;
        }


        [HttpGet("load")]
        public async Task<IActionResult> LoadTestData()
        {
            var res = await _testDataService.LoadAllTestData();
            return ResultOk(res);
        }

        [HttpGet("test")]
        public IActionResult GetTest()
        {
            return Result(new Result(new List<UserViewModel>()
            {
                new UserViewModel()
                {
                    Id = 1,
                    Avatar = "dafgrthy",
                    Name = "efgr",
                    Role = "efgr",
                    CreatedAt = DateTime.UtcNow
                },
                new UserViewModel()
                {
                    Id = 2,
                    Avatar = "regerg",
                    Name = "efeshrggr",
                    Role = "arehsj",
                    CreatedAt = DateTime.UtcNow
                }
            }));
        }
    }
}