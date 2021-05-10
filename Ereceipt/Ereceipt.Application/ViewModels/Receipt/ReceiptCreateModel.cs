using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.Receipt
{
    public class ReceiptCreateModel : RequestModel
    {
        [Required, MinLength(1), MaxLength(100)]
        public string ShopName { get; set; }
        public bool IsImportant { get; set; }
        public double TotalPrice { get; set; }
        public Guid? GroupId { get; set; }
        public List<ProductCreateModel> Products { get; set; }
        public int? CurrencyId { get; set; }
    }
}