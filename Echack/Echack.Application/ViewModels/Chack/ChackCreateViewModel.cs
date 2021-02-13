using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Echack.Application.ViewModels.Chack
{
    public class ChackCreateViewModel : RequestModel
    {
        [Required, MinLength(1), MaxLength(100)]
        public string ShopName { get; set; }
        [Required]
        public bool IsImportant { get; set; } = false;
        public double TotalPrice { get; set; }
        public List<ProductCreateViewModel> Products { get; set; }
        public int UserId { get; set; }
        public Guid GroupId { get; set; }
    }
}