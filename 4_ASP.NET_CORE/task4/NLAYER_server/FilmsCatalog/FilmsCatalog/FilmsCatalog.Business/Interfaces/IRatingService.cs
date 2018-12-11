using FilmsCatalog.Business.Models;
using FilmsCatalog.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsCatalog.Business.Interfaces
{
  public  interface IRatingService
    {
        Task<IList<Rating>> GetAllRatings();
        Task<IList<Rating>> GetRatingByFilmId(int id);
        Task<IList<Rating>> GetRatingByUserId(int id);
        Task<Rating> SetRating(Rating rating, int id);
        Task<RatingMark> GetRatingFromUserAndFilm(int userId, int filmId);
        double GetAverageFilmRating(IList<Rating> ratings);
    }
}
