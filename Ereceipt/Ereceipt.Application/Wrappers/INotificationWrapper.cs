using Ereceipt.Application.ViewModels.Notification;
using Ereceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereceipt.Application.Wrappers
{
    public interface INotificationWrapper
    {
        NotificationViewModel MapNotificationToView(Notification notify);
        List<NotificationViewModel> MapNotificationsToView(List<Notification> notifications);
        public NotificationViewModel GetNewNotificationModel<T>(string content);
        Notification MapToDb<T>(NotificationViewModel<T> model);
    }
}
