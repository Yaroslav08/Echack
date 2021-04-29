using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.Currency
{
    public class CurrencyEditModel : CurrencyCreateModel
    {
        [Required]
        public int Id { get; set; }
    }
}