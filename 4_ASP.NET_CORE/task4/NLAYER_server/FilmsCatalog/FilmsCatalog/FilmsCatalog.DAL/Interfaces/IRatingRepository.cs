using FilmsCatalog.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.DAL.Interfaces
{
    public interface IRatingRepository
    {
        Task<IList<RatingMark>> GetAllRatings();
        IQueryable<RatingMark> GetQueryableAllRatings();
        Task<IList<RatingMark>> GetRatingByFilmId(int id);
        Task<IList<RatingMark>> GetRatingByUserId(int id);
        Task<RatingMark> SetRating(RatingMark rating);
        Task<RatingMark> RemoveRating(RatingMark rating);
        Task<RatingMark> GetRatingFromUserAndFilm(int userId, int filmId);
        Task<RatingMark> UpdateRating(RatingMark rating);
    }
}
