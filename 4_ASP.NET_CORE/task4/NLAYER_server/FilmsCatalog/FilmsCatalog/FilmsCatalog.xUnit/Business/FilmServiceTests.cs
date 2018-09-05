using AutoMapper;
using FilmsCatalog.Business.Interfaces;
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
   public  class FilmServiceTests
    {
        private Mock<IFilmRepository> filmRepository;
        private Mock<IRatingService> ratingService;
        private IMapper mapper;
        public FilmServiceTests()
        {
            filmRepository = new Mock<IFilmRepository>();

            ratingService = new Mock<IRatingService>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            mapper = config.CreateMapper();
        }

        [Fact]
        public void GetAllFilms()
        {
            // Arrange
            filmRepository.Setup(f => f.GetAllFilms()).ReturnsAsync(filmList);
            var service = new FilmService(filmRepository.Object, mapper,ratingService.Object);

            // Act
            var result = service.GetAllFilms();

            // Assert
            var viewResult = Assert.IsType<Task<List<FilmsCatalog.Business.Models.Film>>>(result);
            Assert.NotNull(result.Result);
            Assert.Equal(filmList.Count, result.Result.Count);
        }
        [Fact]
        public void GetFilmById()
        {
            // Arrange
            int filmId = 2;
            filmRepository.Setup(f => f.GetFilmById(filmId)).ReturnsAsync(filmOne);
            var service = new FilmService(filmRepository.Object, mapper, ratingService.Object);

            // Act
            var result = service.GetFilmById(filmId);

            // Assert
            var viewResult = Assert.IsType<Task<FilmsCatalog.Business.Models.Film>>(result);
            Assert.NotNull(result.Result);
            Assert.Equal(filmId, result.Result.Id);
        }

        [Fact]
        public void GetFilmByIdWithGenres()
        {
            // Arrange
            int filmId = 2;
            filmRepository.Setup(f => f.GetFilmByWithGenres(filmId)).ReturnsAsync(filmOne);
            var service = new FilmService(filmRepository.Object, mapper, ratingService.Object);

            // Act
            var result = service.GetFilmByWithGenres(filmId);

            // Assert
            var viewResult = Assert.IsType<Task<FilmsCatalog.Business.Models.FilmWithGenres>>(result);
            Assert.NotNull(result.Result);
            Assert.Equal(filmId, result.Result.Id);
        }
        [Fact]
        public void CreateFilm()
        {
            // Arrange
            filmRepository.Setup(f => f.CreateFilm(filmOne)).ReturnsAsync(filmOne);
            var service = new FilmService(filmRepository.Object, mapper, ratingService.Object);

            // Act
            var result = service.CreateFilm(filmAdd);

            // Assert
            var viewResult = Assert.IsType<Task<FilmsCatalog.Business.Models.Film>>(result);
            Assert.NotNull(result);
        }
        [Fact]
        public void UpdateFilm()
        {
            // Arrange
            filmRepository.Setup(f => f.UpdateFilm(filmOne)).ReturnsAsync(filmOne);
            var service = new FilmService(filmRepository.Object, mapper, ratingService.Object);

            // Act
            var result = service.UpdateFilm(filmAdd);

            // Assert
            var viewResult = Assert.IsType<Task<FilmsCatalog.Business.Models.Film>>(result);
            Assert.NotNull(result);
        }

        private List<Film> filmList = new List<Film>()
        {
            new Film{ Id=1, AverageRating=2.34, Country="test", Description="tesjfjfhjsf", Name="Test1Film", Year=1989, Video="src", Poster="src", Producer="test" },
            new Film{ Id=2, AverageRating=5.34, Country="test", Description="tesjfjfhsdfsdfjsf", Name="Test1Film", Year=1989, Video="src2", Poster="src", Producer="test" },
            new Film{ Id=3, AverageRating=2.34, Country="test", Description="tesjfjffsdfsfhjsf", Name="Test1Film", Year=1999, Video="src3", Poster="src", Producer="test" }
        };

        private Film filmOne = new Film()
        {
            Id=2, AverageRating=5.34, Country="test", Description="tesjfjfhsdfsdfjsf", Name="Test1Film", Year=1989, Video="src2", Poster="src", Producer="test" 
        };

        private FilmsCatalog.Business.Models.Film filmAdd = new FilmsCatalog.Business.Models.Film()
        {
            Id = 2,
            AverageRating = 5.34,
            Country = "test",
            Description = "tesjfjfhsdfsdfjsf",
            Name = "Test1Film",
            Year = 1989,
            Video = "src2",
            Poster = "src",
            Producer = "test"
        };
    }
}
