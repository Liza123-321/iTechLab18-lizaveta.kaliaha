using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Models;
using FilmsCatalog.DAL.Interfaces;
using FilmsCatalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<List<RatingModel>> GetAllRatings()
        {
            return _mapper.Map<List<RatingMark>, List<RatingModel>>(await _ratingRepository.GetAllRatings());
        }

        public  double GetAverageFilmRating(List<RatingModel> ratings)
        {
            double result = 0.0;
            for (int i = 0; i < ratings.Count; i++)
            {
                result += ratings[i].Mark;
            }
            if (ratings.Count > 0) return Math.Round(result / ratings.Count, 2);
            else return 0;
        }

        public async Task<List<RatingModel>> GetRatingByFilmId(int id)
        {

            return _mapper.Map<List<RatingMark>, List<RatingModel>>(await _ratingRepository.GetRatingByFilmId(id));
        }

        public async Task<List<RatingModel>> GetRatingByUserId(int id)
        {
            return _mapper.Map<List<RatingMark>, List<RatingModel>>(await _ratingRepository.GetRatingByUserId(id));
        }

        public async Task<RatingMark> GetRatingFromUserAndFilm(int userId, int filmId)
        {
            return await _ratingRepository.GetRatingFromUserAndFilm(userId,filmId);
        }

        public async Task<RatingModel> SetRating(RatingModel rating, int id)
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
