using System;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.Receipt
{
    public class ProductCreateModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        [Required(ErrorMessage = "CountWeight is required")]
        public double CountWeight { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MinLength(1, ErrorMessage = "Min length of name is 1 symbol")]
        [MaxLength(150, ErrorMessage = "Max length of name is 150 symbols")]
        public string Name { get; set; }
        public double Price { get; set; }
    }
}