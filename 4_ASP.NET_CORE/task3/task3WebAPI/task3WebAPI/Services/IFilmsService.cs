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
        Task<List<FilmModel>> getAllFilms();
        Task<FilmModel>  getByIdFilm(int id);
        Task<FilmModel> createFilm(FilmModel film);
        Task<FilmModel> updateFilm(FilmModel film);
        Task<FilmModel> deleteFilm(int id);
        Task<FilmModel> getFirstOrDefault(int id);
    }
}
