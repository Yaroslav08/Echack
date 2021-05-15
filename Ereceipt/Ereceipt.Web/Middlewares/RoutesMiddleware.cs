using Ereceipt.Web.AppSetting.Errors;
using Ereceipt.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
namespace Ereceipt.Web.Middlewares
{
    public class RoutesMiddleware
    {
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
        private readonly RequestDelegate _next;
        private readonly IErrorStorage _errorStorage;

        public RoutesMiddleware(RequestDelegate next, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider, IErrorStorage errorStorage)
        {
            _next = next;
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
            _errorStorage = errorStorage;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
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
                await SendSuccessResponse(httpContext, new
                {
                    AppName = "Ereceipt",
                    Version = "1.5.2"
                });
            }
            else if (httpContext.Request.Path.Value == "/api/errors")
            {
                await SendSuccessResponse(httpContext, _errorStorage.GetAllErrors());
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