using Ereceipt.Application.ViewModels.User;
using System.Collections.Generic;

namespace Ereceipt.Application.Results.Users
{
    public class ListUsersResult : Result
    {
        public ListUsersResult(List<UserViewModel> users) : base(users) { }
    }
}
