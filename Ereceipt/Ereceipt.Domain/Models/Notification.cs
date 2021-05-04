using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Domain.Models
{
    public class Notification : BaseModelWithIdentityGen<long>
    {
        [Required, MinLength(3), MaxLength(100)]
        public string Title { get; set; }
        [MinLength(4), MaxLength(10000)]
        public string Content { get; set; }
        public NotificationType NotificationType { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadedAt { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }

    public enum NotificationType
    {
        System,
        Login,
        NewReceiptInGroup,
        AddMemberToGroup,
        NewCommentInReceipt
    }
}