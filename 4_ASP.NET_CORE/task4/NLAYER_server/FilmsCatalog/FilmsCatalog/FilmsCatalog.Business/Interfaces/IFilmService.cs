using FilmsCatalog.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsCatalog.Business.Interfaces
{
   public interface IFilmService
    {
        Task<List<Film>> GetAllFilms();
        Task<List<Film>> GetAllFilmsLazy(int page, int pageSize);
        Task<Film> GetFilmById(int id);
        Task<Film> CreateFilm(Film film);
        Task<FilmWithGenres> GetFilmByWithGenres(int id);
        Task<Film> UpdateFilm(Film film);
    }
}
