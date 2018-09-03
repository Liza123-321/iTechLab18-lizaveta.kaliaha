using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Models;
using FilmsCatalog.Business.Profiles;
using FilmsCtalog.WebApi.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FilmsCatalog.xUnit.WebApi
{
   public class PhotoGalleryControllerTests
    {
        private Mock<IPhotoGalleryService> photoService;
        private IMapper mapper;

        public PhotoGalleryControllerTests()
        {
            photoService = new Mock<IPhotoGalleryService>();

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
            photoService.Setup(gallery => gallery.GetAllPhotosGallery()).ReturnsAsync(photoList);
            var controller = new PhotoGalleryController(photoService.Object, mapper);

            // Act
            var result = controller.Get();

            // Assert
            var viewResult = Assert.IsType<Task<List<FilmsCtalog.WebApi.Models.PhotoGallery>>>(result);
            Assert.NotNull(result.Result);
            Assert.Equal(photoList.Count, result.Result.Count);
        }
        [Fact]
        public async void GetAllByFilmId()
        {
            // Arrange
            int filmId = 2;
            photoService.Setup(gallery => gallery.GetGalleryByFilmId(filmId)).ReturnsAsync(photoListByFilm);
            var controller = new PhotoGalleryController(photoService.Object, mapper);

            // Act
            var result = controller.Get(filmId);

            // Assert
            var viewResult = Assert.IsType<Task<List<FilmsCtalog.WebApi.Models.PhotoGallery>>>(result);
            Assert.NotNull(result.Result);
            Assert.Equal(photoListByFilm.Count, result.Result.Count);
        }

        private List<PhotoGallery> photoList = new List<PhotoGallery>()
        {
           new PhotoGallery { Src="test1"},
            new PhotoGallery { Src="test2"},
            new PhotoGallery { Src="test3"}
        };
        private List<PhotoGallery> photoListByFilm = new List<PhotoGallery>()
        {
           new PhotoGallery { Src="test456"},
            new PhotoGallery { Src="test232"},
            new PhotoGallery { Src="test356"}
        };

    }
}
