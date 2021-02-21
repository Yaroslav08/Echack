using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.ViewModels.Chack
{
    public class ProductCreateViewModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        [Required]
        public double CountWeight { get; set; }
        [Required, MinLength(1), MaxLength(150)]
        public string Name { get; set; }
        public double Price { get; set; }
    }
}