using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.ViewModels.BudgetCategory
{
    public class BudgetReceiptCreateModel : RequestModel
    {
        [Required]
        public long BudgetCategoryId { get; set; }
        [Required]
        public Guid ReceiptId { get; set; }
    }
}