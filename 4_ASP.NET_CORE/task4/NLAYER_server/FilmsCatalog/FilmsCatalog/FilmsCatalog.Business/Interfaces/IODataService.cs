using FilmsCatalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilmsCatalog.Business.Interfaces
{
    public interface IODataService
    {
        IQueryable<User> GetQueryableUsers();
        IQueryable<Film> GetQueryableFilms();
        IQueryable<Comment> GetQueryableComments();
        IQueryable<Genre> GetQueryableGenres();
        IQueryable<RatingMark> GetQueryableRatings();
        IQueryable<Photo> GetQueryablePhotos();
    }
}
