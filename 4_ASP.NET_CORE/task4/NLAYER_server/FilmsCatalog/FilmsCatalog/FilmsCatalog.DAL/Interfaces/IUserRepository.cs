using FilmsCatalog.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<IList<User>> GetAllUsers();
        IQueryable<User> GetQueryableAllUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByPassAndEmail(string email, string password);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(User user);
        bool AnyUserWithEmail(string email);
    }
}
