using Ereceipt.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereceipt.Application.Results
{
    public class ListUsersVMResult : Result<List<UserViewModel>>
    {
        public ListUsersVMResult(List<UserViewModel> users) : base(users) { }
    }
}
