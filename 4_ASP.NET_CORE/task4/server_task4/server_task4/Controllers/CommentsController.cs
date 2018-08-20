using Microsoft.AspNetCore.Mvc;
using server_task4.Models;
using server_task4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_task4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;
        public CommentsController(ICommentsService commentsService)
        {
            this._commentsService = commentsService;
        }

        [HttpGet]
        public async Task<List<CommentDTO>> Get()
        {
            return await _commentsService.GetAllComments();
        }

        [HttpGet("{id}")]
        public async Task<List<CommentDTO>> Get(int id)
        {
            return await _commentsService.GetCommentsByFilmId(id);
        }
    }
}
