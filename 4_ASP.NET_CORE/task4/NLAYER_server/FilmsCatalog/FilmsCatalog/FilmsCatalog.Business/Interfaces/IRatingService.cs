using FilmsCatalog.Business.Models;
using FilmsCatalog.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsCatalog.Business.Interfaces
{
  public  interface IRatingService
    {
        Task<List<Rating>> GetAllRatings();
        Task<List<Rating>> GetRatingByFilmId(int id);
        Task<List<Rating>> GetRatingByUserId(int id);
        Task<Rating> SetRating(Rating rating, int id);
        Task<RatingMark> GetRatingFromUserAndFilm(int userId, int filmId);
        double GetAverageFilmRating(List<Rating> ratings);
    }
}
