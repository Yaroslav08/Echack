using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereceipt.Application.Interfaces
{
    public interface ITestDataService
    {
        Task<string> LoadAllTestData();
    }
}
