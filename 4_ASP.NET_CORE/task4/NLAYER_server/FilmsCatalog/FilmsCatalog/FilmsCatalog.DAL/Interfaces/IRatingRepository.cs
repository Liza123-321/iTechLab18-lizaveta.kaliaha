using FilmsCatalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmsCatalog.DAL.Interfaces
{
    public interface IRatingRepository
    {
        Task<List<RatingMark>> GetAllRatings();
        Task<List<RatingMark>> GetRatingByFilmId(int id);
        Task<List<RatingMark>> GetRatingByUserId(int id);
        Task<RatingMark> SetRating(RatingMark rating);
        Task<RatingMark> RemoveRating(RatingMark rating);
        Task<RatingMark> GetRatingFromUserAndFilm(int userId, int filmId);
        Task<RatingMark> UpdateRating(RatingMark rating);
    }
}
