using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Domain.Models
{
    public class Receipt : BaseModel<Guid>
    {
        [Required, MinLength(1), MaxLength(100)]
        public string ShopName { get; set; }
        [MinLength(4), MaxLength(300)]
        public string AddressShop { get; set; }
        [Required, Range(0.1, 999999)]
        public double TotalPrice { get; set; }
        public string Currency { get; set; }
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
        public long? BudgetCategoryId { get; set; }
        public BudgetCategory BudgetCategory { get; set; }
        public List<Comment> Comments { get; set; }
    }
    public enum ReceiptType
    {
        Paymant,
        Internal
    }
}