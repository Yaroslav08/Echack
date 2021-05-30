using System;
namespace Ereceipt.Application.ViewModels.Currency
{
    public class CurrencyRootViewModel : CurrencyViewModel
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}