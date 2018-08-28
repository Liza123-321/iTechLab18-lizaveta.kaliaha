using FilmsCatalog.Business.Models;
using FilmsCatalog.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsCatalog.Business.Interfaces
{
  public  interface IRatingService
    {
        Task<List<RatingModel>> GetAllRatings();
        Task<List<RatingModel>> GetRatingByFilmId(int id);
        Task<List<RatingModel>> GetRatingByUserId(int id);
        Task<RatingModel> SetRating(RatingModel rating, int id);
        Task<RatingMark> GetRatingFromUserAndFilm(int userId, int filmId);
        double GetAverageFilmRating(List<RatingModel> ratings);
    }
}
