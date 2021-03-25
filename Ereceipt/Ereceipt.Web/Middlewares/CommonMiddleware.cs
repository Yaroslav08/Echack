using Ereceipt.Web.Models;
using Ereceipt.Web.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

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
                        .OrderBy(x => x.Type)
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
    }
}
