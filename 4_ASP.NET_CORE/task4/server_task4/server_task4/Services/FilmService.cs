using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server_task4.DAL.Context;
using server_task4.DAL.Models;

namespace server_task4.Services
{
    public class FilmService : IFilmService
    {
        private dbContext db;
        public FilmService(dbContext films)
        {
            this.db = films;
        }
        public Task<Film> CreateFilm(Film film)
        {
            throw new NotImplementedException();
        }

        public Task<Film> DeleteFilm(int id)
        {
            throw new NotImplementedException();
        }

        public async  Task<List<Film>> GetAllFilms()
        {
            return await db.Films.ToListAsync();
        }

        public Task<Film> GetFilmById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Film> UpdateFilm(User user)
        {
            throw new NotImplementedException();
        }
    }
}
