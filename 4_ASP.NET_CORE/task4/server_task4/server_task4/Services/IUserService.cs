using server_task4.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_task4.Services
{
    public interface IUserService
    {

        Task<List<User>> getAllUsers();
        List<User> getAllUsersSync();
        Task<User> getUserById(int id);
        Task<User> register(User user);
        Task<User> updateUser(User user);
        Task<User> deleteUser(int id);
        Task<Object> login(User user);
    }
}
