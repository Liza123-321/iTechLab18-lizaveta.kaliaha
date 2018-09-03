using System.Threading.Tasks;
using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Models;
using FilmsCtalog.WebApi.Models;
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
        public async Task<ActionResult<FilmsCatalog.Business.Models.Login>> Login([FromBody] Models.Login user)
        {

                return new ObjectResult(await _userService.LoginUser(_mapper.Map<Models.Login, FilmsCatalog.Business.Models.Login>(user)));
        }

        [HttpPost("register")]
        public async Task<ActionResult<FilmsCatalog.Business.Models.Login>> Register([FromBody] Models.Login model)
        {
            if (ModelState.IsValid)
            {
                var myUser = await _userService.RegisterUser(_mapper.Map<Models.Login, FilmsCatalog.Business.Models.Login>(model));
                if (myUser == null) return BadRequest(new { message = "This email used by other user" });
                return Ok(model);
            }
            else return BadRequest();
        }
    }
}