using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmsCatalog.BLL.Interfaces;
using FilmsCatalog.BLL.ModelsBLL;
using FilmsCatalog.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmsCtalog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentsService;
        public CommentsController(ICommentService commentsService)
        {
            this._commentsService = commentsService;
        }

  
        [HttpGet("{id}")]
        public async Task<List<CommentWithEmail>> Get(int id)
        {
            return await _commentsService.GetCommentsByFilmId(id);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody]CommentBLL comment)
        {
            var myComment = await _commentsService.AddComment(comment, User.Identity.Name);
            if (myComment == null) return BadRequest(new { message = "BadRequest" });
            return Ok(myComment);
        }
    }
}