using AutoMapper;
using Microsoft.EntityFrameworkCore;
using server_task4.DAL.Context;
using server_task4.DAL.Models;
using server_task4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_task4.Services
{
    public class RatingService : IRatingService
    {
        private dbContext db;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public RatingService(dbContext ratings, IMapper mapper, IUserService userService)
        {
            this._mapper = mapper;
            this.db = ratings;
            this._userService = userService;
        }
        public async Task<List<RatingDTO>> DeleteRatingByFilmId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RatingDTO>> GetAllRatings()
        {
            return _mapper.Map<List<RatingMark>, List<RatingDTO>>(await db.RatingMarks.ToListAsync());
        }

        public async Task<List<RatingDTO>> GetRatingByFilmId(int id)
        {
  
            return  _mapper.Map<List<RatingMark>, List<RatingDTO>>(await (db.RatingMarks.Where(x => x.FilmId == id).ToListAsync()));
        }
        public double GetAverageFilmRating(List<RatingDTO> ratings)
        {
            double result = 0.0;
            for(int i = 0; i < ratings.Count; i++)
            {
                result += ratings[i].Mark;
            }
            if (ratings.Count>0) return Math.Round(result / ratings.Count, 2) ;
            else return 0;

        }

        public async Task<List<RatingDTO>> GetRatingByUserId(int id)
        {
            return _mapper.Map<List<RatingMark>, List<RatingDTO>>(await (db.RatingMarks.Where(x => x.UserId == id).ToListAsync()));
        }

        public async Task<RatingDTO> SetRating(RatingDTO rating,string email)
        {
            rating.UserId = await _userService.GetIdByEmail(email);
            db.RatingMarks.Add(new RatingMark { UserId=rating.UserId, FilmId=rating.FilmId, Mark=rating.Mark});
            await db.SaveChangesAsync();
            return rating;
        }

        public async Task<RatingDTO> UpdateRating(RatingDTO rating)
        {
            throw new NotImplementedException();
        }
    }
}
