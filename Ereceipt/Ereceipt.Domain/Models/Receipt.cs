using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace Ereceipt.Domain.Models
{
    public class Receipt : BaseModelWithIdentityGen<Guid>
    {
        [Required, MinLength(1), MaxLength(100)]
        public string ShopName { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        public string Products { get; set; }
        [Required]
        public bool IsImportant { get; set; } = false;
        [Required]
        public bool CanEdit { get; set; } = true;
        [Required]
        public ReceiptType ReceiptType { get; set; } = ReceiptType.Internal;

        public int UserId { get; set; }
        public User User { get; set; }

        public Guid? GroupId { get; set; }
        public Group Group { get; set; }
    }

    public enum ReceiptType
    {
        Paymant,
        Internal
    }
}