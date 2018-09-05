using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Models;
using FilmsCatalog.Business.Profiles;
using FilmsCatalog.Business.SignalR;
using FilmsCtalog.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FilmsCatalog.xUnit.WebApi
{
    public class CommentsControllerTests
    {
        private Mock<ICommentService> commentService;
        private Mock<IUserService> userService;
        private readonly IHubContext<CommentHub> _hubContext;
        private IMapper mapper;

        public CommentsControllerTests()
        {
            commentService = new Mock<ICommentService>();
            userService = new Mock<IUserService>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            mapper = config.CreateMapper();
        }
        [Fact]
        public async void GetCommentByFilmId()
        {
            // Arrange
            int filmId = 2;
            int userId = 1;
            string userEmail = "test@mail.ru";
            commentService.Setup(c => c.GetCommentsByFilmId(filmId)).ReturnsAsync(commentListByFilm);
            userService.Setup(user => user.GetIdByEmail(userEmail)).ReturnsAsync(userId);
            var controller = new CommentsController(commentService.Object, mapper, userService.Object, _hubContext);

            // Act
            var result = await controller.Get(filmId);

            // Assert
            var viewResult = Assert.IsAssignableFrom<List<FilmsCtalog.WebApi.Models.CommentWithEmail>>(result);
            Assert.NotNull(result);
            Assert.Equal(filmId, result[0].FilmId);
            Assert.Equal(commentListByFilm.Count, result.Count);
        }

        [Fact]
        public async void AddComment()
        {
            // Arrange
            commentService.Setup(c => c.AddComment(comment,1)).ReturnsAsync(commentAdd);
            var controller = new CommentsController(commentService.Object, mapper, userService.Object, _hubContext);

            // Act
            var result = await controller.AddComment(testItem);

            // Assert
            var viewResult = Assert.IsAssignableFrom<IActionResult>(result);
            Assert.NotNull(result);
        }

        private List<CommentWithEmail> commentListByFilm = new List<CommentWithEmail>()
        {
            new CommentWithEmail{ CommentMessage="test", Data="01/01/1996", FilmId=2, UserId=1, Email="test@mail.ru"},
                  new CommentWithEmail{ CommentMessage="test2", Data="01/01/4533", FilmId=2, UserId=2,Email="test546@mail.ru"},
                        new CommentWithEmail{ CommentMessage="test3", Data="01/01/1000", FilmId=2, UserId=1,Email="test@mail.ru"},
        };

        private Comment comment = new Comment
        {
            CommentMessage = "test",
            Data = "01/01/1996",
            FilmId = 2,
            UserId = 0
        };
        private Comment commentAdd = new Comment
        {
            CommentMessage = "test",
            Data = "01/01/1996",
            FilmId = 2,
            UserId = 1
        };

        FilmsCtalog.WebApi.Models.Comment testItem = new FilmsCtalog.WebApi.Models.Comment { CommentMessage = "test", Data = "01/01/1996", FilmId = 2, UserId = 1 };
    }
}
