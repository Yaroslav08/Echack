using Echack.Application.Interfaces;
using Echack.Application.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Echack.Web.Controllers
{
    public class UsersController : BaseController
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateViewModel model)
        {
            var user = await _userService.CreateUser(model);
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers(int afterId)
        {
            var users = await _userService.GetAllUsers(afterId);
            return Ok(users);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }
    }
}
