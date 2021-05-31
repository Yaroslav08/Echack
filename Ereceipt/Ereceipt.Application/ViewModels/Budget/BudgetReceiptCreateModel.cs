using System;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.Budget
{
    public class BudgetReceiptCreateModel : RequestModel
    {
        [Required(ErrorMessage = "Budget ID is required")]
        public long BudgetId { get; set; }
        [Required(ErrorMessage = "Receipt ID is required")]
        public Guid ReceiptId { get; set; }
    }
}