using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace Ereceipt.Application.ViewModels.Receipt
{
    public class ReceiptEditViewModel : RequestModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required, MinLength(1), MaxLength(100)]
        public string ShopName { get; set; }
        public bool IsImportant { get; set; }
        public List<ProductCreateViewModel> Products { get; set; }
    }
}