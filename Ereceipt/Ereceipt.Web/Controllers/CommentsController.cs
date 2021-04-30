using Ereceipt.Application.Extensions;
using Ereceipt.Application.MediatR.Commands;
using Ereceipt.Application.MediatR.Queries;
using Ereceipt.Application.ViewModels.Comment;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
namespace Ereceipt.Web.Controllers
{
    public class CommentsController : ApiController
    {
        IMediator _mediator;
        ILogger<CommentsController> _logger;
        public CommentsController(IMediator mediator, ILogger<CommentsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, SAdmin")]
        public async Task<IActionResult> GetCommentWithDetails(long id)
        {
            var result = await _mediator.Send(new GetCommentWithDetailsQuery(id));
            return Result(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentCreateViewModel model)
        {
            model.IncomeRequestInit(GetId(), GetIpAddress());
            var result = await _mediator.Send(new CreateCommentCommand(model));
            return Result(result);
        }

        [HttpPut]
        public async Task<IActionResult> EditComment([FromBody] CommentEditViewModel model)
        {
            model.IncomeRequestInit(GetId(), GetIpAddress());
            var result = await _mediator.Send(new EditCommentCommand(model));
            return Result(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveComment(long id)
        {
            var result = await _mediator.Send(new RemoveCommentCommand(GetId(), id));
            return Result(result);
        }
    }
}