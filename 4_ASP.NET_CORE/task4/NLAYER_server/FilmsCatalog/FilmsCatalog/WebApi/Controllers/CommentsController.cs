using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCtalog.WebApi.HttpBase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmsCtalog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : UserBaseController
    {
        private readonly ICommentService _commentsService;
        private readonly IMapper _mapper;

        public CommentsController(ICommentService commentsService, IMapper mapper, IUserService userService) :base(userService)
        {
            _commentsService = commentsService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<List<Models.CommentWithEmail>> Get(int id)
        {
            return _mapper.Map<List<FilmsCatalog.Business.Models.CommentWithEmail>, List<Models.CommentWithEmail>> (await _commentsService.GetCommentsByFilmId(id));
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] Models.Comment model)
        {
            if (ModelState.IsValid)
            {
                var myComment = await _commentsService.AddComment(_mapper.Map<Models.Comment, FilmsCatalog.Business.Models.Comment>(model), UserId);
                return Ok(myComment);
            }
            else return BadRequest(new { message = "BadRequest" });
        }
    }
}