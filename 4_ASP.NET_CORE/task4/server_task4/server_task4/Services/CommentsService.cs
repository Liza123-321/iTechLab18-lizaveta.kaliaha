using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using server_task4.DAL.Context;
using server_task4.DAL.Models;
using server_task4.Models;

namespace server_task4.Services
{
    public class CommentsService : ICommentsService
    {
        private dbContext db;
        private readonly IMapper _mapper;
        public CommentsService(dbContext comments, IMapper mapper)
        {
            this._mapper = mapper;
            this.db = comments;
        }
        public async Task<CommentDTO> AddComment(int filmId)
        {
            throw new NotImplementedException();
        }

        public Task<CommentDTO> DeleteCommentById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CommentDTO>> GetAllComments()
        {
            return _mapper.Map<List<Comment>, List<CommentDTO>>(await db.Comments.ToListAsync());
        }

        public async Task<List<CommentDTO>> GetCommentsByFilmId(int id)
        {
            return _mapper.Map<List<Comment>, List<CommentDTO>>(await(db.Comments.Where(x => x.FilmId == id).ToListAsync()));
        }
    }
}
