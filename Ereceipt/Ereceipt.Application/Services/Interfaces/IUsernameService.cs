using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereceipt.Application.Services.Interfaces
{
    public interface IUsernameService
    {
        Task<string> GeneratingNewUsernameAsync(int length = 8);
        Task<bool> UsernameIsBusyAsync(string username);
    }
}
