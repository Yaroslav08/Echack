using Ereceipt.Application.ViewModels.Receipt;
using System.Collections.Generic;
namespace Ereceipt.Application.Interfaces
{
    public interface IProductService
    {
        double GetSum(List<ProductCreateViewModel> products);
    }
}