using FilmsCatalog.DAL.Context;
using FilmsCatalog.DAL.Interfaces;
using FilmsCatalog.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsCatalog.DAL.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private ApplicationContext db;

        public RatingRepository(ApplicationContext ratings)
        {
            this.db = ratings;
        }

        public async Task<List<RatingMark>> GetAllRatings()
        {
            return await db.RatingMarks.ToListAsync();
        }

        public async Task<List<RatingMark>> GetRatingByFilmId(int id)
        {
            return await db.RatingMarks.Where(x => x.FilmId == id).ToListAsync();
        }

        public async Task<List<RatingMark>> GetRatingByUserId(int id)
        {
            return await db.RatingMarks.Where(x => x.UserId == id).ToListAsync();
        }

        public async Task<RatingMark> GetRatingFromUserAndFilm(int userId, int filmId)
        {
            return await db.RatingMarks.FirstOrDefaultAsync(x => x.UserId == userId && x.FilmId == filmId);
        }

        public async Task<RatingMark> SetRating(RatingMark rating)
        {
            db.RatingMarks.Add(rating);
            await db.SaveChangesAsync();
            return rating;
        }

        public async Task<RatingMark> RemoveRating(RatingMark rating)
        {
            db.RatingMarks.Remove(rating);
            await db.SaveChangesAsync();
            return rating;
        }
        public async Task<RatingMark> UpdateRating(RatingMark rating)
        {
            db.RatingMarks.Update(rating);
            await db.SaveChangesAsync();
            return rating;
        }
    }
}
