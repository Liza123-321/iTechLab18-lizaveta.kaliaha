using FilmsCatalog.DAL.Context;
using FilmsCatalog.DAL.Interfaces;
using FilmsCatalog.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsCatalog.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private dbContext db;

        public UserRepository(dbContext users)
        {
            this.db = users;
        }

        public async Task<User> AddUser(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return user;
        }
       public bool AnyUserWithEmail(string email)
        {
            if (db.Users.Any(x => x.Email == email))
            {
                return true;
            }
            else return false;
        }
        public async Task<User> DeleteUser(User user)
        {
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await db.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await db.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await db.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
        public async Task<User> GetUserByPassAndEmail(string email, string password)
        {
            return await db.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }
        public async Task<User> UpdateUser(User user)
        {
            if (!db.Users.Any(x => x.Id == user.Id))
            {
                return null;
            }

            db.Users.Update(user);
            await db.SaveChangesAsync();
            return user;
        }
    }
}
