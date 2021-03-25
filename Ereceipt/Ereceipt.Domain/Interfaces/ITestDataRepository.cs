using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereceipt.Domain.Interfaces
{
    public interface ITestDataRepository
    {
        Task<string> LoadTestDataAsync(string[] products);
    }
}
