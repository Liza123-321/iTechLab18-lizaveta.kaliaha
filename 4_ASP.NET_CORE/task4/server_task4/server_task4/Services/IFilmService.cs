using server_task4.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_task4.Services
{
   public interface IFilmService
    {
        Task<List<Film>> GetAllFilms();
        Task<Film> GetFilmById(int id);
        Task<Film> CreateFilm(Film film);
        Task<Film> UpdateFilm(Film film);
        Task<Film> DeleteFilm(int id);
    }
}
