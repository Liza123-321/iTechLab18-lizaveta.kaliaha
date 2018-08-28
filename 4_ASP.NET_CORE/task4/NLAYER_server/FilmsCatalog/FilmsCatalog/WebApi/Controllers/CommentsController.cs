using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Models;
using FilmsCtalog.WebApi.HttpBase;
using FilmsCtalog.WebApi.Models;
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
        private readonly IMapper _mapper;
        public CommentsController(ICommentService commentsService, IMapper mapper)
        {
            this._commentsService = commentsService;
            this._mapper = mapper;

        }
 
        [HttpGet("{id}")]
        public async Task<List<CommentWithEmailViewModel>> Get(int id)
        {
            return _mapper.Map<List<CommentWithEmailModel>, List<CommentWithEmailViewModel>> (await _commentsService.GetCommentsByFilmId(id));
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody]CommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var myComment = await _commentsService.AddComment(_mapper.Map<CommentViewModel, CommentModel>(model), Int32.Parse(HttpContext.GetUserIdAsync()));
                return Ok(myComment);
            }
            else return BadRequest(new { message = "BadRequest" });
        }
    }
}