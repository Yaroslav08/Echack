using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Domain.Models
{
    public class Currency : BaseModelWithIdentityGen<int>
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