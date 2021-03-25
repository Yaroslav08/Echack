using System;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.Receipt
{
    public class ReceiptGroupCreateModel : RequestModel
    {
        [Required]
        public Guid ReceiptId { get; set; }
        [Required]
        public Guid GroupId { get; set; }
    }
}