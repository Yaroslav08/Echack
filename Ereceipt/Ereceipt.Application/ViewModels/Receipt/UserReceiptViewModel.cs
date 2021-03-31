using System;

namespace Ereceipt.Application.ViewModels.Receipt
{
    public class UserReceiptViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Role { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
