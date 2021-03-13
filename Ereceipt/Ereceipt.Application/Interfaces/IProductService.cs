using Ereceipt.Application.ViewModels.Receipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.Interfaces
{
    public interface IProductService
    {
        double GetSum(List<ProductCreateViewModel> products);
    }
}