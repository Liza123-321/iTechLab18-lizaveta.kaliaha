using FilmsCatalog.Business.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FilmsCatalog.Business.Interfaces
{
  public  interface ITokenService
    {
        Task<TokenModel> LoginUser(string email, string password);
        Task<ClaimsIdentity> GetIdentity(string email, string password);
    }
}
