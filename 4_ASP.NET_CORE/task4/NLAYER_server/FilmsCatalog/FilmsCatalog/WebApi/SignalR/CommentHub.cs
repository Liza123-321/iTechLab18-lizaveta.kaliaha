using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmsCatalog.Business.SignalR
{
   public  class CommentHub : BaseHub
    {
        private readonly ICommentService _commentsService;
        private readonly IMapper _mapper;

        public CommentHub(ICommentService commentsService, IMapper mapper, IUserService userService) :base(userService)
        {
            _commentsService = commentsService;
            _mapper = mapper;
        }
        public async Task SetComment(int id)
        {
            var comments = _commentsService.GetCommentsByFilmId(id).Result;
            await Clients.All.SendAsync("ReceiveComments", comments);
        }
        [Authorize]
        public async Task AddComment(Comment model)
        {
            Comment myComment = await _commentsService.AddComment(model, UserId);
            var comments = _commentsService.GetCommentsByFilmId(model.FilmId).Result;
            await Clients.All.SendAsync("ReceiveComments", comments);
        }
    }
}
