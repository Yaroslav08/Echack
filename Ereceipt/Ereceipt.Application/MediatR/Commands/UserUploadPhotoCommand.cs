using Ereceipt.Application.Results.Users;
using Ereceipt.Application.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ereceipt.Application.MediatR.Commands
{
    public class UserUploadPhotoCommand : IRequest<UserResult>
    {
        public UserUploadPhotoCommand(string path, int userId)
        {
            Path = path;
            UserId = userId;
        }
        public string Path { get; set; }
        public int UserId { get; set; }
    }

    public class UserUploadPhotoCommandHandler : IRequestHandler<UserUploadPhotoCommand, UserResult>
    {
        private readonly IUserService _userService;
        public UserUploadPhotoCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserResult> Handle(UserUploadPhotoCommand request, CancellationToken cancellationToken)
        {
            return await _userService.UploadPictureAsync(request.Path, request.UserId);
        }
    }
}