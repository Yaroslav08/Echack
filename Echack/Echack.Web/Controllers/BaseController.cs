using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Echack.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private string GetIdentityName() => User.Identity.IsAuthenticated ? User.Identity.Name : null;

        private int GetId() => Convert.ToInt32(User.Claims.FirstOrDefault(d => d.Type == "Id").Value);
    }
}
