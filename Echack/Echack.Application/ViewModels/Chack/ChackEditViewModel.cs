using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Echack.Application.ViewModels.Chack
{
    public class ChackEditViewModel : RequestModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required, MinLength(1), MaxLength(100)]
        public string ShopName { get; set; }
        public bool IsImportant { get; set; }
        public double TotalPrice { get; set; }
        public List<ProductCreateViewModel> Products { get; set; }

        public double GetTotalPrice()
        {
            if (Products == null || Products.Count == 0)
            {
                TotalPrice = 0;
                return 0;
            }
            var tprice = Products.Sum(d => d.Price);
            TotalPrice = tprice;
            return tprice;
        }
    }
}