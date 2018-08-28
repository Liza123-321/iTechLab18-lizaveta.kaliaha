using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Models;
using FilmsCatalog.DAL.Interfaces;
using FilmsCatalog.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsCatalog.Business.Services
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _mapper;
        private ICommentRepository _commentRepository;

        public CommentService(IMapper mapper, ICommentRepository commentRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }
        public async Task<CommentModel> AddComment(CommentModel comment,int id)
        {
            comment.UserId = id;
            await _commentRepository.AddComment(Mapper.Map<CommentModel, Comment>(comment));
            return comment;
        }
        public async Task<List<CommentWithEmailModel>> GetCommentsByFilmId(int id)
        {
            return Mapper.Map<List<Comment>, List<CommentWithEmailModel>>(await _commentRepository.GetCommentsByFilmId(id));
        }
    }
}
