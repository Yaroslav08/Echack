using Ereceipt.Web.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
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

        protected IActionResult ResultOk(object data)
        {
            if (data is ICollection)
            {
                if ((data as ICollection) == null || (data as ICollection).Count == 0)
                    return Ok(new APINotFoundResponse());
            }
            if (data == null)
                return Ok(new APINotFoundResponse());
            return Ok(new APIOKResponse(data));
        }
    }
}
