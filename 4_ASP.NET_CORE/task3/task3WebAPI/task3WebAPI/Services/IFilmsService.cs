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
        List<FilmModel> getAllFilms();
        FilmModel getByIdFilm(int id);
        FilmModel createFilm([FromBody]FilmModel film);
        FilmModel updateFilm(int id,[FromBody]FilmModel film);
        FilmModel deleteFilm(int id);
    }
}
