using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.ViewModels.Receipt
{
    public class ProductViewModel
    {
        public string Id { get; set; }
        public double CountWeight { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}