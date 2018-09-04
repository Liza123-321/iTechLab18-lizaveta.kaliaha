using AutoMapper;
using FilmsCatalog.Business.Models;
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
    public class RatingServiceTests
    {
        private Mock<IRatingRepository> ratingRepository;
        private IMapper mapper;
        public RatingServiceTests()
        {
            ratingRepository = new Mock<IRatingRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            mapper = config.CreateMapper();
        }
        [Fact]
        public void GetAll()
        {
            // Arrange
            ratingRepository.Setup(rating => rating.GetAllRatings()).ReturnsAsync(ratingList);
            var service = new RatingService(mapper, ratingRepository.Object);

            // Act
            var result = service.GetAllRatings();

            // Assert
            var viewResult = Assert.IsType<Task<List<Rating>>>(result);
            Assert.NotNull(result.Result);
            Assert.Equal(ratingList.Count, result.Result.Count);
        }
        [Fact]
        public void GetByFilmId()
        {
            // Arrange
            int filmId = 2;
            ratingRepository.Setup(rating => rating.GetRatingByFilmId(filmId)).ReturnsAsync(ratingListOneFilm);
            var service = new RatingService(mapper, ratingRepository.Object);

            // Act
            var result = service.GetRatingByFilmId(filmId);

            // Assert
            var viewResult = Assert.IsType<Task<List<Rating>>>(result);
            Assert.NotNull(result.Result);
            Assert.Equal(ratingListOneFilm.Count, result.Result.Count);
            Assert.Equal(filmId, result.Result[0].FilmId);
        }
        [Fact]
        public void GetByUserId()
        {
            // Arrange
            int userId = 1;
            ratingRepository.Setup(rating => rating.GetRatingByUserId(userId)).ReturnsAsync(ratingListOneUser);
            var service = new RatingService(mapper, ratingRepository.Object);

            // Act
            var result = service.GetRatingByUserId(userId);

            // Assert
            var viewResult = Assert.IsType<Task<List<Rating>>>(result);
            Assert.NotNull(result.Result);
            Assert.Equal(ratingListOneUser.Count, result.Result.Count);
            Assert.Equal(userId, result.Result[0].UserId);
        }


        [Fact]
        public void GetByFilmIdAndUser()
        {
            // Arrange
            int filmId = 1;
            int userId = 2;
            ratingRepository.Setup(rating => rating.GetRatingFromUserAndFilm(userId, filmId)).ReturnsAsync(ratingByFilmAndUser);
            var service = new RatingService(mapper, ratingRepository.Object);

            // Act
            var result = service.GetRatingFromUserAndFilm(userId, filmId);

            // Assert
            var viewResult = Assert.IsType<Task<RatingMark>>(result);
            Assert.NotNull(result.Result);
            Assert.Equal(filmId, result.Result.FilmId);
            Assert.Equal(userId, result.Result.UserId);
        }
        [Fact]
        public void GetAverageFilmRating()
        {
            // Arrange
    
           var service = new RatingService(mapper, ratingRepository.Object);

            // Act
            var result = service.GetAverageFilmRating(ratings);
            var resultError = service.GetAverageFilmRating(ratingsError);

            // Assert
            var viewResult = Assert.IsType<double>(result);
            Assert.Equal(7, result);
            Assert.Equal(0, resultError);
        }
        [Fact]
        public void SetRating()
        {
            // Arrange
            int userId = 2;
            ratingRepository.Setup(rating => rating.SetRating(ratingByFilmAndUser)).ReturnsAsync(ratingByFilmAndUser);
            var service = new RatingService(mapper, ratingRepository.Object);

            // Act
            var result = service.SetRating(ratingSet,userId);

            // Assert
            var viewResult = Assert.IsType<Task<Rating>>(result);
            Assert.NotNull(result.Result);
            Assert.Equal(userId, result.Result.UserId);
            Assert.Equal(ratingByFilmAndUser.FilmId, result.Result.FilmId);
        }
        private List<RatingMark> ratingList = new List<RatingMark>()
        {
            new RatingMark{ Mark=7,FilmId=1,UserId=1, Id=1 },
            new RatingMark{ Mark=9,FilmId=1,UserId=2, Id=2 },
                        new RatingMark{ Mark=10,FilmId=2,UserId=2, Id=3 },
        };
        private List<RatingMark> ratingListOneFilm = new List<RatingMark>()
        {
                        new RatingMark{ Mark=10,FilmId=2,UserId=2, Id=3 },
                        new RatingMark{ Mark=3,FilmId=2,UserId=1, Id=4 },
        };
        private List<RatingMark> ratingListOneUser = new List<RatingMark>()
        {
                        new RatingMark{ Mark=10,FilmId=1,UserId=1, Id=5 },
                        new RatingMark{ Mark=3,FilmId=3,UserId=1, Id=6 },
                         new RatingMark{ Mark=7,FilmId=2,UserId=1, Id=7 },
        };

        private RatingMark ratingByFilmAndUser = new RatingMark { Mark = 10, FilmId = 1, UserId = 2, Id = 8 };

        private Rating ratingSet = new Rating { Mark = 10, FilmId = 1, UserId = 0};

        private List<Rating> ratings = new List<Rating>()
        {
                        new Rating{ Mark=10,FilmId=2,UserId=2 },
                        new Rating{ Mark=4,FilmId=2,UserId=1},
        };

        private List<Rating> ratingsError = new List<Rating>(){ };
    }
}
