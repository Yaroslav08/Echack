using System;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.Budget
{
    public class BudgetEditModel : RequestModel
    {
        [Required]
        public int Id { get; set; }
        [Required, MinLength(2), MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public double Balance { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime StartPeriod { get; set; }
        [Required]
        public DateTime EndPeriod { get; set; }
        public int? CurrencyId { get; set; }
    }
}