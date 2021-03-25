using Ereceipt.Application.ViewModels.User;

namespace Ereceipt.Application.Results.Users
{
    public class UserResult : Result<UserViewModel>
    {
        public UserResult(UserViewModel user) : base(user) { }
    }
}
