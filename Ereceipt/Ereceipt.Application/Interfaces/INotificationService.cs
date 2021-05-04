using Ereceipt.Application.Results.Notifications;
using Ereceipt.Application.ViewModels.Notification;
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
        Task CreateNotificationAsync(NotificationViewModel model);
        Task MarkNotificationAsReadAsync(long id, int userId);
        Task MarkAllNotificationsAsReadAsync(int userId);
    }
}