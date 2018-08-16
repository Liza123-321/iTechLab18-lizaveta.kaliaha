using server_task4.DAL.Models;
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
        Task<User> RegisterUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(int id);
        Task<Object> LoginUser(User user);
    }
}
