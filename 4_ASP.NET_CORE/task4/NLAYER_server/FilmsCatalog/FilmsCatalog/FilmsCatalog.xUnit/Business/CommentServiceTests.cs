using AutoMapper;
using FilmsCatalog.Business.Profiles;
using FilmsCatalog.Business.Services;
using FilmsCatalog.DAL.Interfaces;
using FilmsCatalog.DAL.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FilmsCatalog.xUnit.Business
{
   public class CommentServiceTests
    {
        private Mock<ICommentRepository> commentRepository;
        private IMapper mapper;
        public CommentServiceTests()
        {
            commentRepository = new Mock<ICommentRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            mapper = config.CreateMapper();
        }
        [Fact]
        public void GetCommnetsByFilmId()
        {
            // Arrange
            int filmId = 2;
            commentRepository.Setup(c => c.GetCommentsByFilmId(filmId)).ReturnsAsync(commentList);
            var service = new CommentService(mapper, commentRepository.Object);

            // Act
            var result = service.GetCommentsByFilmId(filmId);

            // Assert
            var viewResult = Assert.IsType<Task<List<FilmsCatalog.Business.Models.CommentWithEmail>>>(result);
            Assert.NotNull(result.Result);
            Assert.Equal(commentList.Count, result.Result.Count);
        }
        [Fact]
        public void AddComment()
        {
            // Arrange
            int userId = 2;
            commentRepository.Setup(c => c.AddComment(commentOne)).ReturnsAsync(commentOne);
            var service = new CommentService(mapper, commentRepository.Object);

            // Act
            var result = service.AddComment(commentBusiness, userId);

            // Assert
            var viewResult = Assert.IsType<Task<FilmsCatalog.Business.Models.Comment>>(result);
            Assert.NotNull(result.Result);
            Assert.Equal(userId, result.Result.UserId);
            Assert.Equal(commentOne.FilmId, result.Result.FilmId);
        }

        private List<Comment> commentList = new List<Comment>()
        {
            new Comment{ Id=1, CommentMessage="test",Data="test", FilmId=2,UserId=1},
                 new Comment{ Id=2, CommentMessage="test2",Data="test2", FilmId=2,UserId=2},
                      new Comment{ Id=3, CommentMessage="test3",Data="test3", FilmId=2,UserId=1},

        };

        private Comment commentOne = new Comment()
        {
            Id=1, CommentMessage="test",Data="test", FilmId=2,UserId=1
        };
        private FilmsCatalog.Business.Models.Comment commentBusiness = new FilmsCatalog.Business.Models.Comment()
        {
            CommentMessage = "test",
            Data = "test",
            FilmId = 2,
            UserId = 1
        };
    }
}
