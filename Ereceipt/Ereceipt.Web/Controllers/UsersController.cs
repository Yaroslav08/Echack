using Ereceipt.Application.MediatR.Commands;
using Ereceipt.Application.MediatR.Queries;
using Ereceipt.Application.ViewModels.User;
using Ereceipt.Web.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ereceipt.Web.Controllers
{
    public class UsersController : BaseController
    {
        IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateViewModel model)
        {
            var result = await _mediator.Send(new UserCreateCommand(model));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, SAdmin")]
        public async Task<IActionResult> GetAllUsers(int afterId = 0)
        {
            var result = await _mediator.Send(new GetAllUsersQuery(afterId));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditUser(int id, [FromBody] UserEditViewModel model)
        {
            model.UserId = id;
            var result = await _mediator.Send(new UserEditCommand(model));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }

        [HttpGet("search")]
        //[Authorize(Roles = "Admin, SAdmin")]
        public async Task<IActionResult> SearchUsers(string name, int afterId = 0)
        {
            var result = await _mediator.Send(new SearchUsersQuery(name, afterId));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }
    }
}
