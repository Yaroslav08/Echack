using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.Receipt;
using System.Collections.Generic;
using System.Linq;
namespace Ereceipt.Application.Services.Implementations
{
    public class ProductService : IProductService
    {
        public double GetSum(List<ProductCreateViewModel> products)
        {
            if (products == null || products.Count == 0)
                return 0;
            return products.Sum(d => d.Price);
        }
    }
}