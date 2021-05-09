using Ereceipt.Application.ViewModels.User;

namespace Ereceipt.Application.Results.Users
{
    public class UserResult : Result
    {
        public UserResult(UserViewModel user) : base(user) { }
        public UserResult(string error) : base(error) { }
    }
}
