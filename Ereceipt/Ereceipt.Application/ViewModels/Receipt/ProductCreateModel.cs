using System;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.Receipt
{
    public class ProductCreateModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        [Required]
        public double CountWeight { get; set; }
        [Required, MinLength(1), MaxLength(150)]
        public string Name { get; set; }
        public double Price { get; set; }
    }
}