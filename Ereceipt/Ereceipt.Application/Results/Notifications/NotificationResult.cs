using Ereceipt.Application.ViewModels.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.Results.Notifications
{
    public class NotificationResult : Result
    {
        public NotificationResult(NotificationViewModel model) : base(model) { }

        public NotificationResult(string error) : base(error) { }
    }
}