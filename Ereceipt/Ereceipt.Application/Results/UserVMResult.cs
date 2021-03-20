using Ereceipt.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereceipt.Application.Results
{
    public class UserVMResult : Result<UserViewModel>
    {
        public UserVMResult(UserViewModel user) : base(user) { }
    }
}
