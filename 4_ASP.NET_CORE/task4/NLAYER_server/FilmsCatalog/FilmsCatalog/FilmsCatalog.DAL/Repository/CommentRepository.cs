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
    public class CommentRepository : ICommentRepository
    {
        private dbContext db;
        public CommentRepository(dbContext comments)
        {
            this.db = comments;
        }
        public async Task<Comment> AddComment(Comment comment)
        {
            db.Comments.Add(comment);
            await db.SaveChangesAsync();
            return comment;
        }

        public async  Task<Comment> DeleteComment(Comment comment)
        {
            db.Comments.Remove(comment);
            await db.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetAllComments()
        {
            return await db.Comments.ToListAsync();
        }

        public async Task<List<Comment>> GetCommentsByFilmId(int id)
        {
            return await db.Comments.Where(x => x.FilmId == id).ToListAsync();
        }
    }
}
