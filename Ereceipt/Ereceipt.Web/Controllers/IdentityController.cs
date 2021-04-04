using Ereceipt.Application.MediatR.Commands;
using Ereceipt.Application.MediatR.Queries;
using Ereceipt.Application.ViewModels.User;
using Ereceipt.Domain.Models;
using Ereceipt.Web.AppSetting;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ereceipt.Web.Controllers
{
    public class IdentityController : ApiController
    {
        IMediator _mediator;
        public IdentityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginViewModel model)
        {
            var result = GetToken(await _mediator.Send(new UserLoginQuery(model)));
            return ResultOk(result, "Login or password is incorrect");
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserCreateViewModel model)
        {
            var result = await _mediator.Send(new UserCreateCommand(model));
            return ResultOk(result);
        }


        [NonAction]
        private TokenResponse GetToken(User user)
        {
            if (user == null)
                return null;
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role),
                    new Claim("Id", user.Id.ToString())
                };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOption.ISSUER,
                    audience: AuthOption.AUDIENCE,
                    notBefore: now,
                    claims: claimsIdentity.Claims,
                    expires: now.Add(TimeSpan.FromDays(AuthOption.LIFETIMEDays)),
                    signingCredentials: new SigningCredentials(AuthOption.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new TokenResponse
            {
                AccessToken = encodedJwt,
                ExpiredAt = DateTime.UtcNow.Add(TimeSpan.FromDays(AuthOption.LIFETIMEDays)),
                Name = user.Name
            };
        }
    }
}
