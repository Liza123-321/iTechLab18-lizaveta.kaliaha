using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Models;
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

        [Fact]
        public async void Get()
        {
            // Arrange
            var films =await GetTestFilmsView();
            var mockMapper = new Mock<IMapper>();
            var mockService = new Mock<IFilmService>();
            mockMapper.Setup(m => m.Map<IEnumerable<Film>, List<FilmsCtalog.WebApi.Models.Film>>(It.IsAny<IEnumerable<Film>>()))
                    .Returns(films);
            mockService.Setup(service=>service.GetAllFilms()).Returns(GetTestFilms());
            var controller = new FilmController(mockService.Object, mockMapper.Object);

            // Act
            var result = controller.Get();

            // Assert
            var viewResult = Assert.IsType<Task<List<FilmsCtalog.WebApi.Models.Film>>>(result);
            Assert.Equal(GetTestFilms().Result.Count, result.Result.Count);
        }

        [Fact]
        public void GetById()
        {
            int filmTestId = 2;
            var testGenres = new List<Genre>();
            testGenres.Add(new Genre { GenreName = "genre1" });
            testGenres.Add(new Genre { GenreName = "genre2" });
            // Arrange
            var mockService = new Mock<IFilmService>();
            mockService.Setup(service => service.GetFilmByWithGenres(filmTestId)).Returns(GetTestFilmWithGenres());
            var film = new FilmsCtalog.WebApi.Models.Film ();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<Film, FilmsCtalog.WebApi.Models.Film>(It.IsAny<Film>()))
                    .Returns(film);
            var controller = new FilmController(mockService.Object, mockMapper.Object);

            // Act
            var result =  controller.GetWithGenres(1);

            // Assert
            //var viewResult = Assert.IsType<Task<IActionResult>>(result);
            Assert.Equal(filmTestId, result.Result.Value.Id);
        }

        [Fact]
        public void Post()
        {

        }

        private async Task<List<FilmsCtalog.WebApi.Models.Film>> GetTestFilmsView()
        {
            var testFilms = new List<FilmsCtalog.WebApi.Models.Film>();
            testFilms.Add(new FilmsCtalog.WebApi.Models.Film { Id = 1, Video = "video", Name = "Мстители", AverageRating = 8.1, Country = "США", Year = 2018, Description = "test", Poster = "test" });
            testFilms.Add(new FilmsCtalog.WebApi.Models.Film { Id = 2, Video = "video2", Name = "FilmTest2", AverageRating = 2.1, Country = "США", Year = 2017, Description = "test3", Poster = "test2" });
            testFilms.Add(new FilmsCtalog.WebApi.Models.Film { Id = 3, Video = "video3", Name = "FilmTest3", AverageRating = 9.1, Country = "США", Year = 2016, Description = "test4", Poster = "test3" });
            return  testFilms;
        }
        private async Task<List<Film>> GetTestFilms()
        {
            var testFilms = new List<Film>();
            testFilms.Add(new Film { Id = 1, Video = "video", Name = "Мстители", AverageRating = 8.1, Country = "США", Year = 2018, Description = "test", Poster = "test" });
            testFilms.Add(new Film { Id = 2, Video = "video2", Name = "FilmTest2", AverageRating = 2.1, Country = "США", Year = 2017, Description = "test3", Poster = "test2" });
            testFilms.Add(new Film { Id = 3, Video = "video3", Name = "FilmTest3", AverageRating = 9.1, Country = "США", Year = 2016, Description = "test4", Poster = "test3" });
            return testFilms;
        }
        private async Task<FilmWithGenres> GetTestFilmWithGenres()
        {
            var testGenres = new List<Genre>();
            testGenres.Add(new Genre { GenreName = "genre1" });
            testGenres.Add(new Genre { GenreName = "genre2" });
            var testFilm = new FilmWithGenres { Id = 2, Video = "video", Name = "Мстители", AverageRating = 8.1, Country = "США", Year = 2018, Description = "test", Poster = "test" , Genres = testGenres };
            return testFilm;
        }
    }
}
