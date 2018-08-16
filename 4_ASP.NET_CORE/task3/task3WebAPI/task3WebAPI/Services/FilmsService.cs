using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task3WebAPI.Context;
using task3WebAPI.Models;

namespace task3WebAPI.Services
{
    public class FilmsService : IFilmsService
    {
        private FilmsContext db;
        public FilmsService(FilmsContext films)
        {
            this.db = films;
        }
        public async Task<FilmModel> CreateFilm(FilmModel film)
        {
            db.Films.Add(film);
            await db.SaveChangesAsync();
            return film;
        }

        public async Task<FilmModel> DeleteFilm(int id)
        {
            FilmModel film = await GetFirstOrDefaultFilm(id);
            if (film == null)
            {
                return null;
            }
            db.Films.Remove(film);
            await db.SaveChangesAsync();
            return film;
        }

        public async Task<List<FilmModel>> GetAllFilms()
        {
            return await db.Films.ToListAsync();
        }

        public async Task<FilmModel> GetFilmById(int id)
        {

            return await db.Films.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<FilmModel> UpdateFilm(FilmModel film)
        {
            if (!db.Films.Any(x => x.Id == film.Id))
            {
                return null;
            }

            db.Films.Update(film);
            await db.SaveChangesAsync();
            return film;
        }

        public async Task<FilmModel> GetFirstOrDefaultFilm(int id)
        {  
            return await db.Films.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
