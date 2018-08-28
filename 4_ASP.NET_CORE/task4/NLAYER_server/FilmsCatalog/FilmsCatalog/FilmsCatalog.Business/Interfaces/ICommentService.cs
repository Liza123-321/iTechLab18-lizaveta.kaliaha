using FilmsCatalog.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsCatalog.Business.Interfaces
{
   public interface ICommentService
    {
        Task<List<CommentWithEmailModel>> GetCommentsByFilmId(int id);
        Task<CommentModel> AddComment(CommentModel comment, int id);
    }
}
