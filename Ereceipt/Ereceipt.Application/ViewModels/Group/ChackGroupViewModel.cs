using Ereceipt.Application.ViewModels.Currency;
using Ereceipt.Application.ViewModels.Receipt;
using System;
using System.Collections.Generic;
namespace Ereceipt.Application.ViewModels.Group
{
    public class ReceiptGroupViewModel : ReceiptComments
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string ShopName { get; set; }
        public double TotalPrice { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public CurrencyViewModel Currency { get; set; }
        public bool IsImportant { get; set; }
        public UserReceiptViewModel User { get; set; }
    }
}
