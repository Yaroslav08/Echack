using Ereceipt.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereceipt.Application.Results
{
    public class UserResult : Result<UserViewModel>
    {
        public UserResult(UserViewModel user) : base(user) { }
    }
}
