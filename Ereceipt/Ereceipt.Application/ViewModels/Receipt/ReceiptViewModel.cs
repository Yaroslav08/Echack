using Ereceipt.Application.ViewModels.Currency;
using Ereceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Ereceipt.Application.ViewModels.Receipt
{
    public class ReceiptViewModel : ReceiptComments
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
        public bool CanEdit { get; set; }
        public ReceiptType ReceiptType { get; set; }
        public UserReceiptViewModel User { get; set; }
        public GroupReceiptViewModel Group { get; set; }
    }
}