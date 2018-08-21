using server_task4.DAL.Models;
using server_task4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_task4.Services
{
    public interface IUserService
    {

        Task<List<User>> GetAllUsers();
        List<User> GetAllUsersSync();
        Task<User> GetUserById(int id);
        Task<LoginDTO> RegisterUser(LoginDTO user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(int id);
        Task<string> GetEmailById(int id);
        Task<int> GetIdByEmail(string email);
        Task<Object> LoginUser(User user);
    }
}
