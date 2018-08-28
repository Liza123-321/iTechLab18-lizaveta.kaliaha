using FilmsCatalog.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsCatalog.DAL.Interfaces
{
   public interface ICommentRepository
    {
        Task<List<Comment>> GetAllComments();
        Task<Comment> DeleteComment(Comment comment);
        Task<Comment> AddComment(Comment comment);
        Task<List<Comment>> GetCommentsByFilmId(int id);
    }
}
