using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.Receipt
{
    public class ReceiptCreateViewModel : RequestModel
    {
        [Required, MinLength(1), MaxLength(100)]
        public string ShopName { get; set; }
        public bool IsImportant { get; set; }
        public double TotalPrice { get; set; }
        public Guid? GroupId { get; set; }
        public List<ProductCreateViewModel> Products { get; set; }
    }
}