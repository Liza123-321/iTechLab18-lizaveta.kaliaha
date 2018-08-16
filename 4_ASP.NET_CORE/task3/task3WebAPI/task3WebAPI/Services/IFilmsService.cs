using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task3WebAPI.Models;

namespace task3WebAPI.Services
{
    public interface IFilmsService
    {
        Task<List<FilmModel>> GetAllFilms();
        Task<FilmModel> GetFilmById(int id);
        Task<FilmModel> CreateFilm(FilmModel film);
        Task<FilmModel> UpdateFilm(FilmModel film);
        Task<FilmModel> DeleteFilm(int id);
        Task<FilmModel> GetFirstOrDefaultFilm(int id);
    }
}
