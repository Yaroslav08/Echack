using System;
namespace Ereceipt.Application.ViewModels.Receipt
{
    public class GroupReceiptViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Desc { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
    }
}