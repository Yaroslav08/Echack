using DeviceDetectorNET;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereceipt.Web.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;
        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            _logger.LogInformation(GetLogString(httpContext));
            await _next(httpContext);
        }

        private string GetLogString(HttpContext context)
        {
            var device = GetDevice(context);
            var requestId = context.TraceIdentifier;
            var connId = context.Connection.Id;
            var ip = context.Connection.RemoteIpAddress.ToString();
            var path = context.Request.Path.Value;
            var protocol = context.Request.Protocol;
            var method = context.Request.Method;
            var user = context.User.Identity.IsAuthenticated ? context.User.Claims.FirstOrDefault(d => d.Type == "Id").Value : "null";
            var isUserAuth = context.User.Identity.IsAuthenticated;
            var authType = context.User.Identity.AuthenticationType;
            return $"User {user} at IP [{ip}] by [{method}:{protocol}] to [{path}] with [{connId}] from [{device}]";
        }

        private string GetDevice(HttpContext context)
        {
            var dd = new DeviceDetector(context.Request.Headers["User-Agent"].ToString());
            dd.SkipBotDetection();
            dd.Parse();
            var deviceName = dd.GetDeviceName();
            var brandName = dd.GetBrandName();
            var model = dd.GetModel();
            var stringBuilder = new StringBuilder();
            if (!string.IsNullOrEmpty(deviceName))
                stringBuilder.Append($"{deviceName}");
            if (!string.IsNullOrEmpty(brandName))
                stringBuilder.Append($" {brandName} ");
            if (!string.IsNullOrEmpty(model))
                stringBuilder.Append($"{model}");
            return stringBuilder.ToString();
        }
    }
}
