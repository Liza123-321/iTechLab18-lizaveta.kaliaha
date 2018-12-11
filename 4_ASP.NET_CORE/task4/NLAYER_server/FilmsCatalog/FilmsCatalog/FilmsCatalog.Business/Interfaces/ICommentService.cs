using FilmsCatalog.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsCatalog.Business.Interfaces
{
   public interface ICommentService
    {
        Task<IList<CommentWithEmail>> GetCommentsByFilmId(int id);
        Task<Comment> AddComment(Comment comment, int id);
    }
}
