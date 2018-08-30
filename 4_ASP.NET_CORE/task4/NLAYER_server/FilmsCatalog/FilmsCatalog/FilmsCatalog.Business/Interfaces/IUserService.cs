using FilmsCatalog.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsCatalog.Business.Interfaces
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
