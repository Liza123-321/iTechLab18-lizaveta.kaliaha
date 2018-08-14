using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using server_task4.DAL.Models;
using server_task4.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace server_task4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Token([FromBody]User user)
        {
            return new ObjectResult(await _userService.login(user));
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _userService.getAllUsers();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]User user)
        {
            var myUser = await _userService.register(user);
            if (user == null) return BadRequest(new { message = "Fail" });
            return Ok(user);

        }
    }
}
