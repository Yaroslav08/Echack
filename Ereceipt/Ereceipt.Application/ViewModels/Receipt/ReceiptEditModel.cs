using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.Receipt
{
    public class ReceiptEditModel : RequestModel
    {
        [Required(ErrorMessage = "ID is required")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "ShopName is required")]
        [MinLength(1, ErrorMessage = "Min length of shopname is 1 symbol")]
        [MaxLength(100, ErrorMessage = "Max length of shopname is 100 symbols")]
        public string ShopName { get; set; }
        [MinLength(4, ErrorMessage = "Min length of addressshop is 4 symbols")]
        [MaxLength(300, ErrorMessage = "Max length of addressshop is 300 symbols")]
        public string AddressShop { get; set; }
        public bool IsImportant { get; set; }
        public List<ProductCreateModel> Products { get; set; }
        public int? CurrencyId { get; set; }
    }
}