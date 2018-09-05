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
  public class FilmControllerTests
    {
        private Mock<IFilmService> filmService;
        private IMapper mapper;

        public FilmControllerTests()
        {
            filmService = new Mock<IFilmService>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            mapper = config.CreateMapper();
        }

        [Fact]
        public async void GetAllFilms()
        {
            // Arrange
            filmService.Setup(film => film.GetAllFilms()).ReturnsAsync(filmList);
            var controller = new FilmController(filmService.Object, mapper);

            // Act
            var result = controller.Get();

            // Assert
            var viewResult = Assert.IsType<Task<List<FilmsCtalog.WebApi.Models.Film>>>(result);
            Assert.NotNull(result.Result);
            Assert.Equal(filmList.Count, result.Result.Count);
        }

        [Fact]
        public async void GetFilmsWithGenres()
        {
            // Arrange
            int filmId = 2;
            filmService.Setup(film => film.GetFilmByWithGenres(filmId)).ReturnsAsync(filmWithGenres);
            var controller = new FilmController(filmService.Object, mapper);

            // Act
            var result = await controller.GetWithGenres(filmId);

            // Assert
            var viewResult = Assert.IsAssignableFrom<ActionResult<FilmsCtalog.WebApi.Models.FilmWithGenres>>(result);
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);
            var filmTest = okResult.Value as FilmsCtalog.WebApi.Models.FilmWithGenres;
            Assert.NotNull(filmTest);
            Assert.Equal(filmId, filmTest.Id);
        }

        private List<Film> filmList = new List<Film>()
        {
            new Film { Id = 1, Video = "video", Name = "Мстители", AverageRating = 8.1, Country = "США", Year = 2018, Description = "test", Poster = "test" },
           new Film { Id = 2, Video = "video2", Name = "FilmTest2", AverageRating = 2.1, Country = "США", Year = 2017, Description = "test3", Poster = "test2" },
           new Film { Id = 3, Video = "video3", Name = "FilmTest3", AverageRating = 9.1, Country = "США", Year = 2016, Description = "test4", Poster = "test3" }
        };

        private FilmWithGenres filmWithGenres = new FilmWithGenres
        {
            Id = 2,
            Video = "video",
            Name = "Мстители",
            AverageRating = 8.1,
            Country = "США",
            Year = 2018,
            Description = "test",
            Poster = "test",
            Genres = new List<Genre>()
            {
                new Genre { GenreName = "genre1" },
                new Genre { GenreName = "genre2" }
            }
        };
    }
}
