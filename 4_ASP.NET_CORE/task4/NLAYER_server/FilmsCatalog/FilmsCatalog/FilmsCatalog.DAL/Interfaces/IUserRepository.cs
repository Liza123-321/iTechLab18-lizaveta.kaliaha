using FilmsCatalog.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsCatalog.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByPassAndEmail(string email, string password);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(User user);
        bool AnyUserWithEmail(string email);
    }
}
