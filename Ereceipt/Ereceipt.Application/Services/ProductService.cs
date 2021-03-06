using Ereceipt.Application.Interfaces;
using Ereceipt.Application.ViewModels.Chack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.Services
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