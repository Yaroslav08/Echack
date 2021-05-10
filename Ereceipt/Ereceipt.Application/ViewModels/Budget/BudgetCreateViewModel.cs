using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.ViewModels.Budget
{
    public class BudgetCreateViewModel : RequestModel
    {
        [Required, MinLength(2), MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int Balance { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime StartPeriod { get; set; }
        [Required]
        public DateTime EndPeriod { get; set; }
        public Guid GroupId { get; set; }
        public int CurrencyId { get; set; }
    }
}