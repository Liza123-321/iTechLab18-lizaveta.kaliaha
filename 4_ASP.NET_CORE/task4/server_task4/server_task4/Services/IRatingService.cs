using server_task4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_task4.Services
{
  public interface IRatingService
    {
        Task<List<RatingDTO>> GetAllRatings();
        Task<List<RatingDTO>> GetRatingByFilmId(int id);
        Task<List<RatingDTO>> GetRatingByUserId(int id);
        Task<RatingDTO> SetRating(RatingDTO rating,string name);
        Task<RatingDTO> UpdateRating(RatingDTO rating);
        Task<List<RatingDTO>> DeleteRatingByFilmId(int id);
        double GetAverageFilmRating(List<RatingDTO> ratings);
    }
}
