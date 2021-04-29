using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.Currency
{
    public class CurrencyCreateModel : RequestModel
    {
        [Required]
        public string Symbol { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public int ISOFormat { get; set; }
        public string Name { get; set; }
        public string Countries { get; set; }
    }
}