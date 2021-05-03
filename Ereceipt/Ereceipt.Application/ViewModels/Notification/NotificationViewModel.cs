using Ereceipt.Application.ViewModels.User;
using Ereceipt.Domain.Models;
using System;
namespace Ereceipt.Application.ViewModels.Notification
{
    public class NotificationViewModel
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public object Content { get; set; }
        public NotificationType NotificationType { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadedAt { get; set; }
        public UserViewModel User { get; set; }
    }
    public class NotificationViewModel<T> : NotificationViewModel
    {
        public NotificationViewModel(T content)
        {
            Content = content;
        }
        public T Content { get; set; }
    }
}