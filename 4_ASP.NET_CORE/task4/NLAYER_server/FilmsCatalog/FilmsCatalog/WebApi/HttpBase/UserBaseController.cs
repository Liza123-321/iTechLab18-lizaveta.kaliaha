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
        private int? _userId;
        public int UserId
        {
            get
            {
                if (_userId == null && User.Identity.Name != null)
                {
                    _userId = _userService.GetIdByEmail(User.Identity.Name).Result;
                    return (int)_userId;
                }
                else return 0;

            }
        }
        public UserBaseController(IUserService userService)
        {
            _userService = userService;
        }
    }
}
    