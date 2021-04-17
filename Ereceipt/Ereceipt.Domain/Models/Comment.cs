using System;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Domain.Models
{
    public class Comment : BaseModelWithIdentityGen<long>
    {
        [Required, MinLength(1), MaxLength(500)]
        public string Text { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Guid ReceiptId { get; set; }
        public Receipt Receipt { get; set; }
    }
}