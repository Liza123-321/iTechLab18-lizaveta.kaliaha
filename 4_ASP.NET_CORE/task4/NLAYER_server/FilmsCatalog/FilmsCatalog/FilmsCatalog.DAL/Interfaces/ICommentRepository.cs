using FilmsCatalog.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.DAL.Interfaces
{
   public interface ICommentRepository
    {
        Task<List<Comment>> GetAllComments();
        IQueryable<Comment> GetQueryableAllComments();
        Task<Comment> DeleteComment(Comment comment);
        Task<Comment> AddComment(Comment comment);
        Task<IList<Comment>> GetCommentsByFilmId(int id);
    }
}
