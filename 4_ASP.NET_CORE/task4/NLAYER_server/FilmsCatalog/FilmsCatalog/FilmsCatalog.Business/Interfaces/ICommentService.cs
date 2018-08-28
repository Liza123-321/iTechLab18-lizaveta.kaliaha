using FilmsCatalog.Business.Models;
using FilmsCatalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmsCatalog.Business.Interfaces
{
   public interface ICommentService
    {
        Task<List<CommentWithEmailModel>> GetCommentsByFilmId(int id);
        Task<CommentModel> AddComment(CommentModel comment, int id);
    }
}
