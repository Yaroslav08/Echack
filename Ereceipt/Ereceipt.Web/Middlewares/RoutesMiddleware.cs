using Ereceipt.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
namespace Ereceipt.Web.Middlewares
{
    public class RoutesMiddleware
    {
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public RoutesMiddleware(RequestDelegate next, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider, IConfiguration configuration)
        {
            _next = next;
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("Name", _configuration["About:Name"]);
            httpContext.Response.Headers.Add("Version", _configuration["About:Version"]);
            httpContext.Response.Headers.Add("LastUpdated", _configuration["About:LastUpdated"]);
            if (httpContext.Request.Path.Value == "/api/routes")
            {
                var result = new ListRoutes<RouteModel>();
                var routes = _actionDescriptorCollectionProvider.ActionDescriptors.Items.Where(
                ad => ad.AttributeRouteInfo != null).Select(ad => new RouteModel
                {
                    Type = (ad.ActionConstraints[0] as HttpMethodActionConstraint).HttpMethods.FirstOrDefault(),
                    Template = ad.AttributeRouteInfo.Template
                }).ToList();
                if (routes != null && routes.Any())
                {
                    result.Items = routes;
                    result.Success = true;
                    result.Count = routes.Count;
                }
                await SendSuccessResponse(httpContext, result);
            }
            else if (httpContext.Request.Path.Value == "/version")
            {
                var appName = _configuration["About:Name"];
                var appVersion = _configuration["About:Version"];
                var lastDateUpdated = _configuration["About:LastDateUpdated"];
                await SendSuccessResponse(httpContext, new
                {
                    AppName = appName,
                    Version = appVersion,
                    LastDateUpdated = lastDateUpdated
                });
            }
            else
            {
                await _next(httpContext);
            }
        }

        private async Task SendSuccessResponse(HttpContext httpContext, object data)
        {
            httpContext.Response.StatusCode = StatusCodes.Status200OK;
            await httpContext.Response.WriteAsJsonAsync(data);
        }
    }
}