using Ereceipt.Application.ViewModels.Receipt;
using System.Collections.Generic;
namespace Ereceipt.Application.Services.Interfaces
{
    public interface IProductService
    {
        double GetSum(List<ProductCreateModel> products);
    }
}