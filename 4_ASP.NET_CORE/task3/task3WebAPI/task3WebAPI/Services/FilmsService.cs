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
            //if (!db.Films.Any())
            //{
            //    db.Films.Add(new FilmModel { Name = "Test",Country="USA",Year=1783,Derictor="Liza" });
            //    db.Films.Add(new FilmModel { Name = "ITechArt", Country = "Belarus", Year = 2007, Derictor = "Liza" });
            //    db.SaveChanges();
            //}
        }
        public async Task<FilmModel> createFilm(FilmModel film)
        {
            db.Films.Add(film);
            await db.SaveChangesAsync();
            return film;
        }

        public async Task<FilmModel> deleteFilm(int id)
        {
            FilmModel film = await getFirstOrDefault(id);
            if (film == null)
            {
                return null;
            }
            db.Films.Remove(film);
            await db.SaveChangesAsync();
            return film;
        }

        public async Task<List<FilmModel>> getAllFilms()
        {
            return await db.Films.ToListAsync();
        }

        public async Task<FilmModel> getByIdFilm(int id)
        {

            return await db.Films.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<FilmModel> updateFilm(FilmModel film)
        {
            if (!db.Films.Any(x => x.Id == film.Id))
            {
                return null;
            }

            db.Films.Update(film);
            await db.SaveChangesAsync();
            return film;
        }

        public async Task<FilmModel> getFirstOrDefault(int id)
        {  
            return await db.Films.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
