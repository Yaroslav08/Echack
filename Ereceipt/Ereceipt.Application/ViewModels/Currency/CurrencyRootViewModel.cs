using System;
namespace Ereceipt.Application.ViewModels.Currency
{
    public class CurrencyRootViewModel : CurrencyViewModel
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}