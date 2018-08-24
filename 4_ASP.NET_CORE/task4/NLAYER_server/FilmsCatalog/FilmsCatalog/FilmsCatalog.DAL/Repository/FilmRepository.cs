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
    public class FilmRepository : IFilmRepository
    {
        private dbContext db;

        public FilmRepository(dbContext films)
        {
            this.db = films;
        }

        public async Task<Film> CreateFilm(Film film)
        {
            if (db.Films.Any(x => x.Name == film.Name))
            {
                return null;
            }
            db.Films.Add(film);
            await db.SaveChangesAsync();
            return film;
        }

        public async Task<Film> DeleteFilm(Film film)
        {
            db.Films.Remove(film);
            await db.SaveChangesAsync();
            return film;
        }

        public async Task<List<Film>> GetAllFilms()
        {
            return await db.Films.ToListAsync();
        }

        public async Task<Film> GetFilmById(int id)
        {
            return  await db.Films.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Film> UpdateFilm(Film film)
        {
            if (!db.Films.Any(x => x.Id == film.Id))
            {
                return null;
            }
            db.Films.Update(film);
            await db.SaveChangesAsync();
            return film;
        }
    }
}
