using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Echack.Application.ViewModels.Chack
{
    public class ProductViewModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public double CountWeight { get; set; }
        public string Name { get; set; }
    }
}