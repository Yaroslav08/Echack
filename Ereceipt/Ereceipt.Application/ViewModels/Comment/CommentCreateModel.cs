using System;
using System.ComponentModel.DataAnnotations;

namespace Ereceipt.Application.ViewModels.Comment
{
    public class CommentCreateModel : RequestModel
    {
        [Required, MinLength(1), MaxLength(500)]
        public string Text { get; set; }
        [Required]
        public Guid ReceiptId { get; set; }
    }
}
