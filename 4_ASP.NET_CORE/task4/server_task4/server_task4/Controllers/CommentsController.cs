using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server_task4.DAL.Models;
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
        public async Task<List<CommentWithEmailDTO>> Get(int id)
        {
            return await _commentsService.GetCommentsByFilmId(id);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody]Comment comment)
        {
            var myComment = await _commentsService.AddComment(comment, User.Identity.Name);
            if (myComment == null) return BadRequest(new { message = "BadRequest" });
            return Ok(myComment);

        }
    }
}
