using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.ViewModels.Notification.Types
{
    public class NotificationLoginViewModel
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string OS { get; set; }
        public string DeviceType { get; set; }
        public string Device { get; set; }
        public string IPAddress { get; set; }
        public string AppType { get; set; }
    }
}