using FilmsCatalog.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmsCatalog.Business.Interfaces
{
  public interface IGenreService
    {
        Task<List<GenreModel>> GetAllGenres();
        Task<GenreWithFilmModel> GetGenreByNameWithFilms(string name);
    }
}
