using Ereceipt.Application.Extensions;
using Ereceipt.Application.MediatR.Commands;
using Ereceipt.Application.MediatR.Queries;
using Ereceipt.Application.ViewModels.User;
using Ereceipt.Web.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
namespace Ereceipt.Web.Controllers.V1
{
    public class UsersController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UsersController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SAdmin")]
        public async Task<IActionResult> GetAllUsers(int afterId = 0)
        {
            var result = await _mediator.Send(new GetAllUsersQuery(afterId));
            return Result(result);
        }

        [HttpPut]
        public async Task<IActionResult> EditUser([FromBody] UserEditModel model)
        {
            model.IncomeRequestInit(GetId(), GetIpAddress());
            var result = await _mediator.Send(new EditUserCommand(model));
            return Result(result);
        }

        [HttpPost("picture")]
        public async Task<IActionResult> UploadPicture([FromForm] IFormFile picture)
        {
            if (picture is null || picture.Length == 0)
                return Ok(new APIBadRequestResponse("Picture is empty"));
            var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
            var path = Path.Combine(uploads, $"{Guid.NewGuid()}.{picture.FileName.Split('.')[1]}");
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await picture.CopyToAsync(fileStream);
            }
            var result = await _mediator.Send(new UserUploadPhotoCommand(path, GetId()));
            return Result(result);
        }

        [HttpGet("search")]
        [Authorize(Roles = "Admin, SAdmin")]
        public async Task<IActionResult> SearchUsers(string name, int afterId = 0)
        {
            if (name.Length <= 2)
                return ResultBadRequest("\"Name\" must be more than 2 characters");
            var result = await _mediator.Send(new SearchUsersQuery(name, afterId));
            return Result(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));
            return Result(result);
        }
    }
}