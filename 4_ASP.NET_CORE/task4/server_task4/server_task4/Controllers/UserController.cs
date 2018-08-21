using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using server_task4.DAL.Models;
using server_task4.Models;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Token([FromBody]User user)
        {
            return new ObjectResult(await _userService.LoginUser(user));
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _userService.GetAllUsers();
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]LoginDTO user)
        {
            var myUser = await _userService.RegisterUser(user);
            if (myUser == null) return BadRequest(new { message = "This email used by other user" });
            return Ok(user);

        }
    }
}
