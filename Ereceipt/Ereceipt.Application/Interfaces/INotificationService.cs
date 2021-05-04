using Ereceipt.Application.Results.Notifications;
using Ereceipt.Application.ViewModels.Notification;
using Ereceipt.Application.ViewModels.Notification.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.Interfaces
{
    public interface INotificationService
    {
        Task<NotificationResult> GetNotificationByIdAsync(long id, int userId);
        Task<ListNotificationResult> GetUnreadNotificationsAsync(int userId);
        Task<ListNotificationResult> GetAllNotificationsAsync(int userId, int afterId);
        Task MarkNotificationAsReadAsync(long id, int userId);
        Task MarkAllNotificationsAsReadAsync(int userId);

        Task CreateNotificationAsync(NotificationViewModel model, NotificationLoginViewModel content);
        Task CreateNotificationAsync(NotificationViewModel model, string content);
        Task CreateNotificationAsync(NotificationViewModel model, NotificationReceiptInGroupViewModel content);
        Task CreateNotificationAsync(NotificationViewModel model, NotificationMemberGroupViewModel content);
        Task CreateNotificationAsync(NotificationViewModel model, NotificationCommentReceiptViewModel content);
    }
}