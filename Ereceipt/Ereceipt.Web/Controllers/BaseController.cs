using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Ereceipt.Web.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BaseController : ControllerBase
    {
        protected string GetIdentityName() => User.Identity.IsAuthenticated ? User.Identity.Name : null;

        protected int GetId() 
        {
            if (User.Identity.IsAuthenticated)
                return Convert.ToInt32(User.Claims.FirstOrDefault(d => d.Type == "Id").Value);
            return 1;
        }
    }
}
