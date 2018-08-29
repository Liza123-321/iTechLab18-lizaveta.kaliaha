using FilmsCatalog.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsCatalog.Business.Interfaces
{
   public interface ICommentService
    {
        Task<List<CommentWithEmail>> GetCommentsByFilmId(int id);
        Task<Comment> AddComment(Comment comment, int id);
    }
}
