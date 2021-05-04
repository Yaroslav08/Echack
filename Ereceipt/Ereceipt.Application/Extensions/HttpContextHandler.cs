using Ereceipt.Application.ViewModels.Notification.Types;
using Microsoft.AspNetCore.Http;
using DeviceDetectorNET;
using System.Text;
using System;
using System.Linq;

namespace Ereceipt.Application.Extensions
{
    public static class HttpContextHandler
    {
        public static NotificationLoginViewModel GetNotificationLoginData(this HttpContext httpContext)
        {
            var useAgent = httpContext.Request.Headers["User-Agent"].ToString();
            var dd = new DeviceDetector(useAgent);
            dd.SkipBotDetection();
            dd.Parse();
            var nlm = new NotificationLoginViewModel();
            nlm.Id = Guid.NewGuid().ToString("N");
            nlm.AppType = $"{dd.GetClient().Matches[0].Type}";
            nlm.CreatedAt = DateTime.UtcNow;
            nlm.DeviceType = dd.GetDeviceName().First().ToString().ToUpper() + dd.GetDeviceName().Substring(1);
            var device = $"{dd.GetBrandName()} {dd.GetModel()}";
            if (!string.IsNullOrWhiteSpace(device))
            {
                nlm.Device = device;
            }
            nlm.OS = $"{dd.GetOs().Matches[0].Name} {dd.GetOs().Matches[0].Version}";
            nlm.IPAddress = httpContext.Connection.RemoteIpAddress.ToString();
            return nlm;
        }
    }
}
