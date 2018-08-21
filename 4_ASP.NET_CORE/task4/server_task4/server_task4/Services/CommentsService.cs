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
        private readonly IUserService _userService;
        public CommentsService(dbContext comments, IMapper mapper, IUserService userService)
        {
            this._mapper = mapper;
            this.db = comments;
            this._userService = userService;
        }
        public async Task<CommentDTO> AddComment(Comment comment,string name)
        {
            comment.UserId =await _userService.GetIdByEmail(name);
            db.Comments.Add(comment);
            await db.SaveChangesAsync();
            return _mapper.Map<Comment, CommentDTO>(comment);
        }

        public Task<CommentDTO> DeleteCommentById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CommentDTO>> GetAllComments()
        {
            return _mapper.Map<List<Comment>, List<CommentDTO>>(await db.Comments.ToListAsync());
        }

        public async Task<List<CommentWithEmailDTO>> GetCommentsByFilmId(int id)
        {
            var comments = _mapper.Map<List<Comment>, List<CommentDTO>>(await (db.Comments.Where(x => x.FilmId == id).ToListAsync()));
            List<CommentWithEmailDTO> commentsWithEmail = new List<CommentWithEmailDTO>();
            for(int i = 0; i < comments.Count; i++)
            {
                commentsWithEmail.Add(new CommentWithEmailDTO { CommentMessage = comments[i].CommentMessage, Data = comments[i].Data, UserName = await _userService.GetEmailById(comments[i].UserId) });
            }
            return commentsWithEmail;
        }
    }
}
