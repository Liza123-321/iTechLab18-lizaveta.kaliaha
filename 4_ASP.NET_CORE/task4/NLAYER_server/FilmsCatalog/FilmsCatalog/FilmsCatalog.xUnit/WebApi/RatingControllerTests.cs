using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Models;
using FilmsCatalog.Business.Profiles;
using FilmsCtalog.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FilmsCatalog.xUnit.WebApi
{
    public class RatingControllerTests
    {
        private Mock<IRatingService> ratingService;
        private Mock<IUserService> userService;
        private IMapper mapper;

        public RatingControllerTests()
        {
            ratingService = new Mock<IRatingService>();

            userService = new Mock<IUserService>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            mapper = config.CreateMapper();
        }
        [Fact]
        public async void GetAllRatings()
        {
            // Arrange
            ratingService.Setup(rating => rating.GetAllRatings()).ReturnsAsync(ratingList);
            var controller = new RatingController(ratingService.Object, mapper,userService.Object);

            // Act
            var result = controller.Get();

            // Assert
            var viewResult = Assert.IsType<Task<List<FilmsCtalog.WebApi.Models.Rating>>>(result);
            Assert.NotNull(result.Result);
            Assert.Equal(ratingList.Count, result.Result.Count);
        }
        [Fact]
        public async void GetAllRatingsByFilm()
        {
            // Arrange
           int filmId = 1;
            ratingService.Setup(rating => rating.GetRatingByFilmId(filmId)).ReturnsAsync(ratingListByFilm);
            ratingService.Setup(rating => rating.GetAverageFilmRating(ratingListByFilm)).Returns(8);
            var controller = new RatingController(ratingService.Object, mapper, userService.Object);

            // Act
            var result = controller.Get(filmId);

            // Assert
            var viewResult = Assert.IsType<Task<double>>(result);
            Assert.Equal(8, result.Result);
        }
        //public async Task<IActionResult> AddRating([FromBody] Models.Rating model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return Ok(await _ratingService.SetRating(_mapper.Map<Models.Rating, FilmsCatalog.Business.Models.Rating>(model), UserId));
        //    }
        //    else return BadRequest();
        //}
        [Fact]
        public async void AddRating()
        {
            // Arrange
            int filmId = 1;
            int userId = 1;
            string userEmail = "test@mail.ru";
            ratingService.Setup(rating => rating.SetRating(addRating,filmId)).ReturnsAsync(addRating);
            userService.Setup(user => user.GetIdByEmail(userEmail)).ReturnsAsync(userId);
            var controller = new RatingController(ratingService.Object, mapper, userService.Object);

            // Act
            var result = await controller.AddRating(addRatingWebApi);

            // Assert
            var viewResult = Assert.IsAssignableFrom<IActionResult>(result);
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
        }


        private List<Rating> ratingList = new List<Rating>()
        {
            new Rating{ Mark=7,FilmId=1,UserId=1 },
             new Rating{ Mark=5,FilmId=2,UserId=1 },
              new Rating{ Mark=2,FilmId=3,UserId=1 },
               new Rating{ Mark=9,FilmId=1,UserId=2 },
        };

        private List<Rating> ratingListByFilm = new List<Rating>()
        {
            new Rating{ Mark=7,FilmId=1,UserId=1 },
               new Rating{ Mark=9,FilmId=1,UserId=2 },
        };

        private Rating addRating = new Rating
        {
            Mark=9,FilmId=1,UserId=1
        };
        private FilmsCtalog.WebApi.Models.Rating addRatingWebApi = new FilmsCtalog.WebApi.Models.Rating
        {
            Mark = 9,
            FilmId = 1,
            UserId = 1
        };
    }
}
