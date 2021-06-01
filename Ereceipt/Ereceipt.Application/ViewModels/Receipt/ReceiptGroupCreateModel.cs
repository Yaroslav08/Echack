using System;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.Receipt
{
    public class ReceiptGroupCreateModel : RequestModel
    {
        [Required(ErrorMessage = "ReceiptID is required")]
        public Guid ReceiptId { get; set; }
        [Required(ErrorMessage = "GroupID is required")]
        public Guid GroupId { get; set; }
    }
}