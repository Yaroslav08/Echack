using Ereceipt.Application.MediatR.Commands;
using Ereceipt.Application.ViewModels.Authentication;
using Ereceipt.Web.AppSetting;
using Ereceipt.Web.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
namespace Ereceipt.Web.Controllers.V1
{
    public class IdentityController : ApiController
    {
        private readonly IMediator _mediator;
        public IdentityController(IMediator mediator) => _mediator = mediator;

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = GetToken(await _mediator.Send(new LoginCommand(model)));
            return Result(result, "Login or password is incorrect");
        }


        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterModel model, [FromServices] IWebHostEnvironment _webHostEnvironment)
        {
            var photoId = Guid.NewGuid().ToString("N");
            model.Photo = _webHostEnvironment.WebRootPath + @$"\Images\{photoId}.png";
            var result = await _mediator.Send(new RegisterCommand(model));
            if (result.IsError)
                return Ok(new APIBadRequestResponse(result.Error));
            return Ok(new APIOKResponse("Successed registered!"));
        }


        [NonAction]
        private TokenResult GetToken(LoginViewModel user)
        {
            if (user.IsError)
                return new TokenResult(user.Error);
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
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
            var token = new TokenResponse
            {
                AccessToken = encodedJwt,
                ExpiredAt = DateTime.UtcNow.Add(TimeSpan.FromDays(AuthOption.LIFETIMEDays)),
                Name = user.Name
            };
            return new TokenResult(token);
        }
    }
}