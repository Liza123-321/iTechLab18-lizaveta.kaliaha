using FilmsCatalog.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsCatalog.Business.Interfaces
{
   public interface IFilmService
    {
        Task<IList<Film>> GetAllFilms();
        Task<IList<Film>> GetAllFilmsLazy(int page, int pageSize);
        Task<Film> GetFilmById(int id);
        Task<Film> CreateFilm(Film film);
        Task<FilmWithGenres> GetFilmByWithGenres(int id);
        Task<Film> UpdateFilm(Film film);
    }
}
