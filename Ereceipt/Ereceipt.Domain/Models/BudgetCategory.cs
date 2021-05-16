using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ereceipt.Domain.Models
{
    public class BudgetCategory : BaseModel<long>
    {
        [Required, MinLength(1), MaxLength(100)]
        public string Name { get; set; }
        public int BudgetId { get; set; }
        public Budget Budget { get; set; }
        public List<Receipt> Receipts { get; set; }
    }
}