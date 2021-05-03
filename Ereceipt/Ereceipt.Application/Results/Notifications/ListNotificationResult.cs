using Ereceipt.Application.ViewModels.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereceipt.Application.Results.Notifications
{
    public class ListNotificationResult : Result
    {
        public ListNotificationResult(List<NotificationViewModel> models) : base(models) { }
    }
}
