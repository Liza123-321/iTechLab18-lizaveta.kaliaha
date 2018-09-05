using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.SignalR;
using FilmsCtalog.WebApi.Controllers;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FilmsCatalog.Tests
{
   public class CommentControllerTests
    {
        private readonly ICommentService _commentsService;
        private readonly IHubContext<CommentHub> _hubContext;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        [Fact]
        public void GetInvalidFilmId()
        {
            //CommentsController controller = new CommentsController(_commentsService, _mapper, _userService,_hubContext);
            //var res = controller.Get(-1);
            var res = 5;
            Assert.Equal(3, res);
        }
    }
}
