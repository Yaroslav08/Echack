using Ereceipt.Application.MediatR.Commands;
using Ereceipt.Application.MediatR.Queries;
using Ereceipt.Application.ViewModels.Comment;
using MediatR;
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
        public async Task<IActionResult> GetCommentWithDetails(long id)
        {
            var result = await _mediator.Send(new GetCommentWithDetailsQuery(id));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentCreateViewModel model)
        {
            model.UserId = GetId();
            model.IP = GetIpAddress();
            var result = await _mediator.Send(new CreateCommentCommand(model));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }

        [HttpPut]
        public async Task<IActionResult> EditComment([FromBody] CommentEditViewModel model)
        {
            model.UserId = GetId();
            model.IP = GetIpAddress();
            var result = await _mediator.Send(new EditCommentCommand(model));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveComment(long id)
        {
            var result = await _mediator.Send(new RemoveCommentCommand(GetId(), id));
            if (result.OK)
                return ResultOk(result.Data);
            return ResultBadRequest(result.Error);
        }
    }
}