using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Models;
using FilmsCatalog.Business.Profiles;
using FilmsCtalog.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FilmsCatalog.xUnit.WebApi
{
    public class GenreControllerTests
    {
        private Mock<IGenreService> genreService;
        private IMapper mapper;

        public GenreControllerTests()
        {
            genreService = new Mock<IGenreService>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            mapper = config.CreateMapper();
        }
        [Fact]
        public async void GetAll()
        {
            // Arrange
            genreService.Setup(genre => genre.GetAllGenres()).ReturnsAsync(genreList);
            var controller = new GenreController(genreService.Object, mapper);

            // Act
            var result = controller.Get();

            // Assert
            var viewResult = Assert.IsType<Task<List<FilmsCtalog.WebApi.Models.Genre>>>(result);
            Assert.NotNull(result.Result);
            Assert.Equal(genreList.Count, result.Result.Count);
        }
        [Fact]
        public async void GetWithFilms()
        {
            // Arrange
            string genreName = "genre3";
            genreService.Setup(genre => genre.GetGenreByNameWithFilms(genreName)).ReturnsAsync(genreWithFilm);
            var controller = new GenreController(genreService.Object, mapper);

            // Act
            var result = await controller.GetWithFilms(genreName);

            // Assert
            var viewResult = Assert.IsAssignableFrom<ActionResult<FilmsCtalog.WebApi.Models.GenreWithFilm>>(result);
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);
            var genreTest = okResult.Value as FilmsCtalog.WebApi.Models.GenreWithFilm;
            Assert.NotNull(genreTest);
            Assert.Equal(genreName, genreTest.GenreName);
        }



        private List<Genre> genreList = new List<Genre>()
        {
           new Genre { GenreName = "genre1" },
                new Genre { GenreName = "genre2" }
        };

        private GenreWithFilm genreWithFilm = new GenreWithFilm
        {
            GenreName = "genre3",
            Films = new List<Film>()
            {
                new Film
                {
                    Id = 1,
                Video = "video",
                Name = "Мстители",
                AverageRating = 8.1,
                Country = "США",
                Year = 2018,
                Description = "test",
                Poster = "test",
                },
                new Film
                {
                    Id = 2,
                Video = "video2",
                Name = "Мстители2",
                AverageRating = 6.1,
                Country = "США",
                Year = 2018,
                Description = "test",
                Poster = "test",
                }
            }
        };
    }
}