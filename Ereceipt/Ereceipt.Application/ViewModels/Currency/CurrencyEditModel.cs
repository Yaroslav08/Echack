using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.Currency
{
    public class CurrencyEditModel : CurrencyCreateModel
    {
        [Required(ErrorMessage = "ID is required")]
        public int Id { get; set; }
    }
}