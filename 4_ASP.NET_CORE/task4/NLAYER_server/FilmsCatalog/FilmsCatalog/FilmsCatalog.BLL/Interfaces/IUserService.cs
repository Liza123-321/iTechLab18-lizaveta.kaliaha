using FilmsCatalog.BLL.ModelsBLL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmsCatalog.BLL.Interfaces
{
    public interface IUserService
    {
        Task<List<Login>> GetAllUsers();
        Task<Login> GetUserById(int id);
        Task<Login> RegisterUser(Login user);
        Task<string> GetEmailById(int id);
        Task<int> GetIdByEmail(string email);
        Task<Token> LoginUser(Login user);
    }
}
