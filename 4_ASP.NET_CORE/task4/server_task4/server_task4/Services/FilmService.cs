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
        private readonly IRatingService _ratingService;
        public FilmService(dbContext films, IRatingService ratingService)
        {
            this.db = films;
            this._ratingService = ratingService;
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

        public async Task<Film> DeleteFilm(int id)
        {
            Film film = db.Films.FirstOrDefault(x => x.Id == id);
            if (film == null)
            {
                return null;
            }
            db.Films.Remove(film);
            await db.SaveChangesAsync();
            return film;
        }

        public async  Task<List<Film>> GetAllFilms()
        {
            return await SetFilmsRating( await db.Films.ToListAsync());
        }

        private async Task<List<Film>> SetFilmsRating(List<Film> films)
        {
            for(int i = 0; i < films.Count; i++)
            {
                films[i].AverageRating = _ratingService.GetAverageFilmRating(await _ratingService.GetRatingByFilmId(films[i].Id));
            }
            return films;
        }

        public async Task<Film> GetFilmById(int id)
        {
            return await SetFilmRating(await db.Films.FirstOrDefaultAsync(x => x.Id == id));
        }
        private async Task<Film> SetFilmRating(Film film)
        {
            film.AverageRating = _ratingService.GetAverageFilmRating(await _ratingService.GetRatingByFilmId(film.Id));
            return film;
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
