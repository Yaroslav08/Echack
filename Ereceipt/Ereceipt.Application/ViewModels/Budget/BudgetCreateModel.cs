using System;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.Budget
{
    public class BudgetCreateModel : RequestModel
    {
        [Required(ErrorMessage = "Name is required"), MinLength(2, ErrorMessage = "Min length of name is 2 symbols"), MaxLength(50, ErrorMessage = "Max length of name is 50 symbols")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Balance is required")]
        public double Balance { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "StartPeriod is required")]
        public DateTime StartPeriod { get; set; }
        [Required(ErrorMessage = "EndPeriod is required")]
        public DateTime EndPeriod { get; set; }
        public Guid GroupId { get; set; }
        public int CurrencyId { get; set; }
    }
}