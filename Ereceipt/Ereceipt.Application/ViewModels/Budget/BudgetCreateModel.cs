using System;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.Budget
{
    public class BudgetCreateModel : RequestModel
    {
        [Required, MinLength(2), MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public double Balance { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime StartPeriod { get; set; }
        [Required]
        public DateTime EndPeriod { get; set; }
        public Guid GroupId { get; set; }
        public int CurrencyId { get; set; }
    }
}