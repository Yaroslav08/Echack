using Ereceipt.Application.ViewModels.Receipt;
using Ereceipt.Application.ViewModels.User;
using System;

namespace Ereceipt.Application.ViewModels.Comment
{
    public class CommentViewModel
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Text { get; set; }
        public UserReceiptViewModel User { get; set; }
        public ReceiptViewModel Receipt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}