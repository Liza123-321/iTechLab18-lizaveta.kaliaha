using FilmsCatalog.Business.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmsCatalog.Business.SignalR
{
   public class BaseHub : Hub
    {
        private readonly IUserService _userService;
        private int? _userId;
        public int UserId
        {
            get
            {
                if (_userId == null && Context.User.Identity.Name != null)
                {
                    _userId = _userService.GetIdByEmail(Context.User.Identity.Name).Result;
                    return (int)_userId;
                }
                else return 0;

            }
        }
        public BaseHub(IUserService userService)
        {
            _userService = userService;
        }
    }
}
