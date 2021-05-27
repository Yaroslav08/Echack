using System;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.Budget
{
    public class BudgetReceiptCreateModel : RequestModel
    {
        [Required]
        public long BudgetId { get; set; }
        [Required]
        public Guid ReceiptId { get; set; }
    }
}