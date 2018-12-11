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
    public class GenreRepository : IGenreRepository
    {
        private ApplicationContext db;

        public GenreRepository(ApplicationContext genres)
        {
            this.db = genres;
        }

        public async Task<Genre> CreateGenre(Genre genre)
        {
            if (db.Genres.Any(x => x.GenreName == genre.GenreName))
            {
                return null;
            }
            db.Genres.Add(genre);
            await db.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre> DeleteGenre(Genre genre)
        {
            db.Genres.Remove(genre);
            await db.SaveChangesAsync();
            return genre;
        }

        public async Task<List<Genre>> GetAllGenres()
        {
            return await db.Genres.ToListAsync();
        }

        public IQueryable<Genre> GetQueryableAllGenres()
        {
            return db.Genres;
        }

        public async Task<Genre> GetGenreById(int id)
        {
            return await db.Genres.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Genre> GetGenreByNameWithFilms(string name)
        {
            return await db.Genres.Include(u => u.FilmGenres).ThenInclude(e => e.Film).FirstOrDefaultAsync(x => x.GenreName == name);
        }

        public async Task<Genre> UpdateGenre(Genre genre)
        {
            if (!db.Genres.Any(x => x.Id == genre.Id))
            {
                return null;
            }
            db.Genres.Update(genre);
            await db.SaveChangesAsync();
            return genre;
        }
    }
}
