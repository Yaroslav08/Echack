using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace Ereceipt.Web.Logging
{
    public class Logger
    {
        RequestDelegate _next;
        public Logger(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, ILoggerRepo repo)
        {
            if (context.Request.Path.Value.Contains("/api/logs"))
            {
                await _next.Invoke(context);
                return;
            }
            var log = new Log
            {
                Path = context.Request.Path,
                Method = context.Request.Method,
                QueryString = context.Request.QueryString.ToString()
            };
            try
            {
                using var swapStream = new MemoryStream();
                var originalResponseBody = context.Response.Body;
                context.Response.Body = swapStream;
                log.RequestedOn = DateTime.Now;
                if (context.Request.Method == "POST" || context.Request.Method == "PUT")
                {
                    context.Request.EnableBuffering();
                    var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
                    context.Request.Body.Position = 0;
                    log.Payload = body;
                }
                await _next.Invoke(context);
                swapStream.Seek(0, SeekOrigin.Begin);
                log.Response = await new StreamReader(swapStream).ReadToEndAsync();
                swapStream.Seek(0, SeekOrigin.Begin);
                await swapStream.CopyToAsync(originalResponseBody);
                context.Response.Body = originalResponseBody;
                log.ResponseCode = context.Response.StatusCode.ToString();
                log.IsSuccessStatusCode = (context.Response.StatusCode == 200 || context.Response.StatusCode == 201);
                log.RespondedOn = DateTime.Now;
                log.RequestTime = (log.RespondedOn - log.RequestedOn).TotalMilliseconds;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                log.Exception = ex;
            }
            finally
            {
                log.User = GetUser(context);
                repo.AddToLogs(log);
            }
        }
        public User GetUser(HttpContext context)
        {
            if (!context.User.Identity.IsAuthenticated)
                return null;
            return new User
            {
                Id = context.User.Claims.First(x => x.Type == "Id").Value,
                Name = context.User.Claims.First(x => x.Type == "Name").Value,
                Role = context.User.Claims.First(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value,
                Username = context.User.Claims.First(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value
            };
        }
    }
}