using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmsCatalog.BLL.Interfaces;
using FilmsCatalog.BLL.ModelsBLL;
using FilmsCatalog.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmsCtalog.WebApi.Controllers
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
        public async Task<IActionResult> GetToken([FromBody]Login user)
        {
            return new ObjectResult(await _userService.LoginUser(user));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]Login user)
        {
            var myUser = await _userService.RegisterUser(user);
            if (myUser == null) return BadRequest(new { message = "This email used by other user" });
            return Ok(user);

        }
    }
}