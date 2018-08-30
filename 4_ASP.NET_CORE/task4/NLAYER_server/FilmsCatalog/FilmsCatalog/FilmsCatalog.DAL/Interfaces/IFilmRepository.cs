using FilmsCatalog.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsCatalog.DAL.Interfaces
{
  public  interface IFilmRepository
    {
        Task<List<Film>> GetAllFilms();
        Task<Film> GetFilmById(int id);
        Task<Film> GetFilmByWithGenres(int id);
        Task<Film> CreateFilm(Film film);
        Task<Film> UpdateFilm(Film film);
        Task<Film> DeleteFilm(Film film);
    }
}
