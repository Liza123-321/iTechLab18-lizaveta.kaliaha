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
   public class GenreServiceTests
    {
        private Mock<IGenreRepository> genreRepository;
        private IMapper mapper;
        public GenreServiceTests()
        {
            genreRepository = new Mock<IGenreRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            mapper = config.CreateMapper();
        }
        [Fact]
        public void GetAllGenres()
        {
            // Arrange
            genreRepository.Setup(g => g.GetAllGenres()).ReturnsAsync(genreList);
            var service = new GenreService(mapper, genreRepository.Object);

            // Act
            var result = service.GetAllGenres();

            // Assert
            var viewResult = Assert.IsType<Task<List<FilmsCatalog.Business.Models.Genre>>>(result);
            Assert.NotNull(result.Result);
            Assert.Equal(genreList.Count, result.Result.Count);
        }
        [Fact]
        public void GetGenreByNameWithFilms()
        {
            // Arrange
            string genreName = "test1";
            genreRepository.Setup(g => g.GetGenreByNameWithFilms(genreName)).ReturnsAsync(genreWithFilm);
            var service = new GenreService(mapper, genreRepository.Object);

            // Act
            var result = service.GetGenreByNameWithFilms(genreName);

            // Assert
            var viewResult = Assert.IsType<Task<FilmsCatalog.Business.Models.GenreWithFilm>>(result);
            Assert.NotNull(result.Result);
            Assert.Equal(genreName, result.Result.GenreName);
        }

        private List<Genre> genreList = new List<Genre>()
        {
            new Genre{ Id=1, GenreName="test1" },
            new Genre{ Id=2, GenreName="test2" },
            new Genre{ Id=3, GenreName="test3" },
        };

        private Genre genreWithFilm = new Genre()
        {
           Id=1, GenreName="test1"
        };
    }
}
