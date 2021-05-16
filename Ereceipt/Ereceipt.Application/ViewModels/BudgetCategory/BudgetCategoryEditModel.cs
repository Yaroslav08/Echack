using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.BudgetCategory
{
    public class BudgetCategoryEditModel : BudgetCategoryCreateModel
    {
        [Required]
        public long Id { get; set; }
    }
}