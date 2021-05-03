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
        NotificationViewModel<T> MapToView<T>(Notification notification);
        Notification MapToDb<T>(NotificationViewModel<T> model);
    }
}
