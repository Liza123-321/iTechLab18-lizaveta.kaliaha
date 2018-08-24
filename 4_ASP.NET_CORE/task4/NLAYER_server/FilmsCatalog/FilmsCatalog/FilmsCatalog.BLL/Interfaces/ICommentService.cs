using FilmsCatalog.BLL.ModelsBLL;
using FilmsCatalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmsCatalog.BLL.Interfaces
{
   public interface ICommentService
    {
        Task<List<CommentWithEmail>> GetCommentsByFilmId(int id);
        Task<CommentBLL> AddComment(CommentBLL comment, string email);
    }
}
