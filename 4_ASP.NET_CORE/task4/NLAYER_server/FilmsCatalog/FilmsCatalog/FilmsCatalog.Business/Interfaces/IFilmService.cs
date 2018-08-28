using FilmsCatalog.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsCatalog.Business.Interfaces
{
   public interface IFilmService
    {
        Task<List<FilmModel>> GetAllFilms();
        Task<FilmModel> GetFilmById(int id);
        Task<FilmModel> CreateFilm(FilmModel film);
        Task<FilmWithGenresModel> GetFilmByWithGenres(int id);
        Task<FilmModel> UpdateFilm(FilmModel film);
    }
}
