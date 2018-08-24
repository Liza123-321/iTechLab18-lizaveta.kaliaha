using FilmsCatalog.BLL.ModelsBLL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmsCatalog.BLL.Interfaces
{
   public interface IFilmService
    {
        Task<List<FilmBLL>> GetAllFilms();
        Task<FilmBLL> GetFilmById(int id);
        Task<FilmBLL> CreateFilm(FilmBLL film);
        Task<FilmBLL> UpdateFilm(FilmBLL film);
    }
}
