using System;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.BudgetCategory
{
    public class BudgetCategoryCreateModel : RequestModel
    {
        [Required, MinLength(1), MaxLength(100)]
        public string Name { get; set; }
        [MinLength(1), MaxLength(100)]
        public string Description { get; set; }
        public int BudgetId { get; set; }
        public Guid GroupId { get; set; }
    }
}