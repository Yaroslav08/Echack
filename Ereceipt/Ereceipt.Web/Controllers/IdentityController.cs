using Ereceipt.Application.MediatR.Commands;
using Ereceipt.Application.ViewModels.Authentication;
using Ereceipt.Web.AppSetting;
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
namespace Ereceipt.Web.Controllers
{
    public class IdentityController : ApiController
    {
        IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public IdentityController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = GetToken(await _mediator.Send(new LoginCommand(model)));
            return Result(result, "Login or password is incorrect");
        }


        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            model.Photo = _webHostEnvironment.WebRootPath + @"\Images\Photo.png";
            var result = await _mediator.Send(new RegisterCommand(model));
            return Result(result);
        }


        [NonAction]
        private TokenResult GetToken(LoginViewModel user)
        {
            if (user == null)
                return new TokenResult("Login or password is incorrect");
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
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