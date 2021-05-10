using Ereceipt.Web.AppSetting.Errors;
using Ereceipt.Web.Models;
using Microsoft.AspNetCore.Http;
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
                var result = new ListResult<RouteModel>();
                var routes = _actionDescriptorCollectionProvider.ActionDescriptors.Items.Where(
                    ad => ad.AttributeRouteInfo != null).Select(ad =>
                    new RouteModel
                    {
                        Type = httpContext.Request.Method,
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
                return;
            }
            else if (httpContext.Request.Path.Value == "/version")
            {
                httpContext.Response.StatusCode = StatusCodes.Status200OK;
                await httpContext.Response.WriteAsJsonAsync(new
                {
                    AppName = "Ereceipt",
                    Version = "1.5.1"
                });
                return;
            }
            else if (httpContext.Request.Path.Value == "/api/errors")
            {
                httpContext.Response.StatusCode = StatusCodes.Status200OK;
                await httpContext.Response.WriteAsJsonAsync(_errorStorage.GetAllErrors());
                return;
            }
            await _next(httpContext);
        }
    }
}
