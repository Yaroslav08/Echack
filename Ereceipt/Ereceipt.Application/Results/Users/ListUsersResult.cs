using Ereceipt.Application.ViewModels.User;
using System.Collections.Generic;

namespace Ereceipt.Application.Results.Users
{
    public class ListUsersResult : Result<List<UserViewModel>>
    {
        public ListUsersResult(List<UserViewModel> users) : base(users) { }
    }
}
