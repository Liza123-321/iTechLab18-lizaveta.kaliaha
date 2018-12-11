using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Models;
using FilmsCatalog.DAL.Interfaces;
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
        public async Task<Models.Comment> AddComment(Models.Comment comment,int id)
        {
            comment.UserId = id;
            await _commentRepository.AddComment(_mapper.Map<Models.Comment, DAL.Models.Comment>(comment));
            return comment;
        }
        public async Task<IList<CommentWithEmail>> GetCommentsByFilmId(int id)
        {
            return _mapper.Map<IList<DAL.Models.Comment>, IList<CommentWithEmail>>(await _commentRepository.GetCommentsByFilmId(id));
        }
    }
}
