using FilmsCatalog.BLL.ModelsBLL;
using FilmsCatalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmsCatalog.BLL.Interfaces
{
  public  interface IRatingService
    {
        Task<List<Rating>> GetAllRatings();
        Task<List<Rating>> GetRatingByFilmId(int id);
        Task<List<Rating>> GetRatingByUserId(int id);
        Task<Rating> SetRating(Rating rating, string email);
        Task<RatingMark> GetRatingFromUserAndFilm(int userId, int filmId);
        double GetAverageFilmRating(List<Rating> ratings);
    }
}
