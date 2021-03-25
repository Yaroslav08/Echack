using Ereceipt.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ereceipt.Web.Middlewares
{
    public class RoutesMiddleware
    {
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
        private readonly RequestDelegate _next;
        private readonly ILogger<RoutesMiddleware> _logger;
        public RoutesMiddleware(RequestDelegate next, ILogger<RoutesMiddleware> logger, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _logger = logger;
            _next = next;
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            _logger.LogInformation($"Request to {httpContext.Request.Path}");
            if (httpContext.Request.Path.Value != "/api/routes")
                await _next(httpContext);
            var result = new ListResult<RouteModel>();
            var routes = _actionDescriptorCollectionProvider.ActionDescriptors.Items.Where(
                ad => ad.AttributeRouteInfo != null).Select(ad =>
                new RouteModel
                {
                    Type = ((ad.EndpointMetadata[6]) as HttpMethodMetadata).HttpMethods[0],
                    Template = ad.AttributeRouteInfo.Template
                })
                .OrderBy(x=>x.Type)
                .ToList();
            if (routes != null && routes.Any())
            {
                result.Items = routes;
                result.Success = true;
                result.Count = routes.Count;
            }
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = StatusCodes.Status200OK;
            await httpContext.Response.WriteAsJsonAsync(result);
        }
    }
}
