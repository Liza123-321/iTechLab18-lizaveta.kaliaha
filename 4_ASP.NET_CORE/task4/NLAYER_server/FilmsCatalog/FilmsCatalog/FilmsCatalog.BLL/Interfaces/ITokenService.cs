using FilmsCatalog.BLL.ModelsBLL;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FilmsCatalog.BLL.Interfaces
{
  public  interface ITokenService
    {
        Task<Token> LoginUser(string email, string password);
        Task<ClaimsIdentity> GetIdentity(string email, string password);
    }
}
