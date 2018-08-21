using server_task4.DAL.Models;
using server_task4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_task4.Services
{
    public interface ICommentsService
    {
        Task<List<CommentDTO>> GetAllComments();
        Task<List<CommentWithEmailDTO>> GetCommentsByFilmId(int id);
        Task<CommentDTO> DeleteCommentById(int id);
        Task<CommentDTO> AddComment(Comment comment, string name);
    }
}
