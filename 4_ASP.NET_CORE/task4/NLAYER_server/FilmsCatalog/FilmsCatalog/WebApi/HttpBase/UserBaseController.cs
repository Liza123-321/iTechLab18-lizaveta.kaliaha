using FilmsCatalog.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FilmsCtalog.WebApi.HttpBase
{
    public class UserBaseController: ControllerBase
    {
        private readonly IUserService _userService;
        //private Lazy<Task<int>> _userId = new Lazy<Task<int>>(async() => await _userService2.GetIdByEmail(User.Identity.Name));
        //public Task<int> UserLazy => _userId.Value;
        private Task<int> _userId;
        public Task<int> UserId
        {
            get
            {
                if (_userId == null)
                {
                    _userId = _userService.GetIdByEmail(User.Identity.Name);
                }
                return _userId;
            }
        }
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
    