using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.SignalR;
using FilmsCtalog.WebApi.HttpBase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FilmsCtalog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : UserBaseController
    {
        private readonly ICommentService _commentsService;
        private readonly IHubContext<CommentHub> _hubContext;
        private readonly IMapper _mapper;

        public CommentsController(ICommentService commentsService, IMapper mapper, IUserService userService, IHubContext<CommentHub> hubContext) :base(userService)
        {
            _commentsService = commentsService;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        [HttpGet("{id}")]
        public async Task<List<Models.CommentWithEmail>> Get(int id)
        {
          
            return _mapper.Map<List<FilmsCatalog.Business.Models.CommentWithEmail>, List<Models.CommentWithEmail>> (await _commentsService.GetCommentsByFilmId(id));
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Models.Comment>> AddComment([FromBody] Models.Comment model)
        {
            if (ModelState.IsValid)
            {
                var myComment = await _commentsService.AddComment(_mapper.Map<Models.Comment, FilmsCatalog.Business.Models.Comment>(model), UserId);
                var allComments = _mapper.Map<List<FilmsCatalog.Business.Models.CommentWithEmail>, List<Models.CommentWithEmail>>(await _commentsService.GetCommentsByFilmId(model.FilmId));
                await _hubContext.Clients.All.SendAsync("GetComment", allComments);
                return Ok(myComment);
            }
            else return BadRequest(new { message = "BadRequest" });
        }
    }
}