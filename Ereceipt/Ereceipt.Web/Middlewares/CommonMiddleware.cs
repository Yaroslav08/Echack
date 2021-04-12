using Ereceipt.Web.Models;
using Ereceipt.Web.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DeviceDetectorNET;
using System.IO;
using System.Text;

namespace Ereceipt.Web.Middlewares
{
    public class CommonMiddleware
    {
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
        private readonly RequestDelegate _next;
        private readonly ILogger<CommonMiddleware> _logger;
        public CommonMiddleware(RequestDelegate next, ILogger<CommonMiddleware> logger, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _logger = logger;
            _next = next;
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            //_logger.LogInformation($"User [{httpContext.Connection.RemoteIpAddress}] from [{dd.GetDeviceName()} - {dd.GetBrandName()} {dd.GetModel()}] to [{httpContext.Request.Path.Value}]");
            _logger.LogInformation(GetLogString(httpContext));

            try
            {
                if (httpContext.Request.Path.Value == "/api/routes")
                {
                    var result = new ListResult<RouteModel>();
                    var routes = _actionDescriptorCollectionProvider.ActionDescriptors.Items.Where(
                        ad => ad.AttributeRouteInfo != null).Select(ad =>
                        new RouteModel
                        {
                            Type = ((ad.EndpointMetadata[6]) as HttpMethodMetadata).HttpMethods[0],
                            Template = ad.AttributeRouteInfo.Template
                        })
                        .OrderBy(x => x.Template)
                        .ToList();
                    if (routes != null && routes.Any())
                    {
                        result.Items = routes;
                        result.Success = true;
                        result.Count = routes.Count;
                    }
                    httpContext.Response.StatusCode = StatusCodes.Status200OK;
                    await httpContext.Response.WriteAsJsonAsync(result);
                }
                else if (httpContext.Request.Path.Value == "/version")
                {
                    httpContext.Response.StatusCode = StatusCodes.Status200OK;
                    await httpContext.Response.WriteAsJsonAsync(new
                    {
                        AppName = "Ereceipt",
                        Version = "1.0.1"
                    });
                }
                else
                {
                    await _next(httpContext);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsJsonAsync(new APIInternalServerErrorResponse());
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
            var userName = context.User.Identity.Name;
            var isUserAuth = context.User.Identity.IsAuthenticated;
            var authType = context.User.Identity.AuthenticationType;
            return device;
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
