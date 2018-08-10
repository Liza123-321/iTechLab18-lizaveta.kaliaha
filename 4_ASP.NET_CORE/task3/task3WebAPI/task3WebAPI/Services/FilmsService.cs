using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            if (!db.Films.Any())
            {
                db.Films.Add(new FilmModel { Name = "Test",Country="USA",Year=1783,Derictor="Liza" });
                db.Films.Add(new FilmModel { Name = "ITechArt", Country = "Belarus", Year = 2007, Derictor = "Liza" });
                db.SaveChanges();
            }
        }
        public FilmModel createFilm([FromBody] FilmModel film)
        {
            if(film == null)
            {
                return null;
            }
            db.Films.Add(film);
            db.SaveChanges();
            return film;
        }

        public FilmModel deleteFilm(int id)
        {
            FilmModel film = db.Films.FirstOrDefault(x => x.Id == id);
            if (film == null)
            {
                return null;
            }
            db.Films.Remove(film);
            db.SaveChanges();
            return film;
        }

        public List<FilmModel> getAllFilms()
        {
            return db.Films.ToList();
        }

        public FilmModel getByIdFilm(int id)
        {
            return db.Films.FirstOrDefault(x => x.Id == id);
        }

        public FilmModel updateFilm(int id, [FromBody] FilmModel film)
        {
            if (film == null)
            {
                return null;
            }
            if (!db.Films.Any(x => x.Id == film.Id))
            {
                return null;
            }

            db.Update(film);
            db.SaveChanges();
            return film;
        }
    }
}
