using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Models;
using FilmsCatalog.DAL.Interfaces;
using FilmsCatalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsCatalog.Business.Services
{
    public class RatingService : IRatingService
    {
        private readonly IMapper _mapper;
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IMapper mapper, IRatingRepository ratingRepository)
        {
            _mapper = mapper;
            _ratingRepository = ratingRepository;
        }

        public async Task<List<Rating>> GetAllRatings()
        {
            return _mapper.Map<List<RatingMark>, List<Rating>>(await _ratingRepository.GetAllRatings());
        }

        public  double GetAverageFilmRating(List<Rating> ratings)
        {
            double result = 0.0;
            for (int i = 0; i < ratings.Count; i++)
            {
                result += ratings[i].Mark;
            }
            if (ratings.Count > 0) return Math.Round(result / ratings.Count, 2);
            else return 0;
        }

        public async Task<List<Rating>> GetRatingByFilmId(int id)
        {

            return _mapper.Map<List<RatingMark>, List<Rating>>(await _ratingRepository.GetRatingByFilmId(id));
        }

        public async Task<List<Rating>> GetRatingByUserId(int id)
        {
            return _mapper.Map<List<RatingMark>, List<Rating>>(await _ratingRepository.GetRatingByUserId(id));
        }

        public async Task<RatingMark> GetRatingFromUserAndFilm(int userId, int filmId)
        {
            return await _ratingRepository.GetRatingFromUserAndFilm(userId,filmId);
        }

        public async Task<Rating> SetRating(Rating rating, int id)
        {
            rating.UserId = id;
            var ratingMark = await GetRatingFromUserAndFilm(rating.UserId, rating.FilmId);
            if (ratingMark != null)
            {
              await  _ratingRepository.RemoveRating(ratingMark);
            }
            await _ratingRepository.SetRating(new RatingMark { UserId = rating.UserId, FilmId = rating.FilmId, Mark = rating.Mark });
            return rating;
        }
    }
}
