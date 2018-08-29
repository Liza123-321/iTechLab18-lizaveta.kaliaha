using FilmsCatalog.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FilmsCtalog.WebApi.HttpBase
{
    public class UserBaseController: ControllerBase
    {
        private readonly IUserService _userService;

        public UserBaseController(IUserService userService)
        {
            _userService = userService;
        }

        async public Task<int> GetUserIdAsync()
        {
            return await _userService.GetIdByEmail(User.Identity.Name);
        }
    }
}
    