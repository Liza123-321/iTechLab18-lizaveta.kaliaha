using FilmsCatalog.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.DAL.Interfaces
{
  public  interface IFilmRepository
    {
        Task<IList<Film>> GetAllFilms();
        IQueryable<Film> GetQueryableAllFilms();
        Task<IList<Film>> GetAllFilmsLazy(int page, int pageSize);
        Task<Film> GetFilmById(int id);
        Task<Film> GetFilmByWithGenres(int id);
        Task<Film> CreateFilm(Film film);
        Task<Film> UpdateFilm(Film film);
        Task<Film> DeleteFilm(Film film);
    }
}
