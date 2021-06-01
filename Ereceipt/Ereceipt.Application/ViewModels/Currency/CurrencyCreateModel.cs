using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.Currency
{
    public class CurrencyCreateModel : RequestModel
    {
        [Required(ErrorMessage = "Symbol is required")]
        public string Symbol { get; set; }
        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "ISO Format is required")]
        public int ISOFormat { get; set; }
        public string Name { get; set; }
        public string Countries { get; set; }
    }
}