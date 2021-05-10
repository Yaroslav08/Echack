using Ereceipt.Application.ViewModels.Currency;
using Ereceipt.Application.ViewModels.Group;
using System;
namespace Ereceipt.Application.ViewModels.Budget
{
    public class BudgetViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public string Description { get; set; }
        public DateTime StartPeriod { get; set; }
        public DateTime EndPeriod { get; set; }
        public GroupViewModel Group { get; set; }
        public CurrencyViewModel Currency { get; set; }
    }
}