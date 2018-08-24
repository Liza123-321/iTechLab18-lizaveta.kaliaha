using AutoMapper;
using FilmsCatalog.BLL.Interfaces;
using FilmsCatalog.BLL.ModelsBLL;
using FilmsCatalog.DAL.Interfaces;
using FilmsCatalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmsCatalog.BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private ICommentRepository _commentRepository;

        public CommentService(IMapper mapper, IUserService userService, ICommentRepository commentRepository)
        {
            _mapper = mapper;
            _userService = userService;
            _commentRepository = commentRepository;
        }
        //fix
        public async Task<CommentBLL> AddComment(CommentBLL comment, string email)
        {
           comment.UserId = await _userService.GetIdByEmail(email);
            await _commentRepository.AddComment(Mapper.Map<CommentBLL, Comment>(comment));
            return comment;
        }

        public async Task<List<CommentWithEmail>> GetCommentsByFilmId(int id)
        {
            var comments = _mapper.Map<List<Comment>, List<CommentBLL>>(await _commentRepository.GetCommentsByFilmId(id));
            List<CommentWithEmail> commentsWithEmail = new List<CommentWithEmail>();
            for (int i = 0; i < comments.Count; i++)
            {
                commentsWithEmail.Add(new CommentWithEmail { CommentMessage = comments[i].CommentMessage, Data = comments[i].Data, UserName = await _userService.GetEmailById(comments[i].UserId)});
            }
            return commentsWithEmail;
        }
    }
}
