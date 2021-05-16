using Ereceipt.Application.ViewModels.Budget;
using Ereceipt.Application.ViewModels.Receipt;
using System;
using System.Collections.Generic;
namespace Ereceipt.Application.ViewModels.BudgetCategory
{
    public class BudgetCategoryViewModel
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BudgetViewModel Budget { get; set; }
        public List<ReceiptViewModel> Receipts { get; set; }
    }
}