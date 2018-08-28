using FilmsCatalog.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmsCatalog.Business.Interfaces
{
    public interface IUserService
    {
        Task<List<LoginModel>> GetAllUsers();
        Task<LoginModel> GetUserById(int id);
        Task<LoginModel> RegisterUser(LoginModel user);
        Task<string> GetEmailById(int id);
        Task<int> GetIdByEmail(string email);
        Task<TokenModel> LoginUser(LoginModel user);
    }
}
