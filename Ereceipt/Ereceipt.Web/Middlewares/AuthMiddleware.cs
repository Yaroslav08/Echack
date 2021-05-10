using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Ereceipt.Web.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var token = httpContext.Request.Query["token"].ToString();
            if (string.IsNullOrEmpty(httpContext.Request.Headers["Authorization"]) && !string.IsNullOrEmpty(token))
            {
                httpContext.Request.Headers["Authorization"] = $"Bearer {token}";
            }
            await _next(httpContext);
        }
    }
}
