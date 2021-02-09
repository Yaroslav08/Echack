using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace Echack.Domain.Models
{
    public class Chack : BaseModelWithIdentityGen<Guid>
    {
        [Required, MinLength(1), MaxLength(100)]
        public string ShopName { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        public string Products { get; set; }
        [Required]
        public bool IsImportant { get; set; } = false;
    }
}