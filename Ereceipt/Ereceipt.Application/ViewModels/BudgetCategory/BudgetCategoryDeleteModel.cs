using System;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.BudgetCategory
{
    public class BudgetCategoryDeleteModel : RequestModel
    {
        public Guid GroupId { get; set; }
        public Guid GroupMemberId { get; set; }
        [Required]
        public long BudgetCategoryId { get; set; }
    }
}