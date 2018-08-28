using FilmsCatalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmsCatalog.DAL.Interfaces
{
    public interface IGenreRepository
    {
        Task<Genre> CreateGenre(Genre genre);
        Task<Genre> DeleteGenre(Genre genre);
        Task<List<Genre>> GetAllGenres();
        Task<Genre> GetGenreByIdWithFilms(int id);
        Task<Genre> GetGenreById(int id);
        Task<Genre> UpdateGenre(Genre genre);
    }
}
