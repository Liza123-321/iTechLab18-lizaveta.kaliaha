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
  public  class PhotoGalleryServiceTests
    {
        private Mock<IPhotoRepository> photoRepository;
        private IMapper mapper;
        public PhotoGalleryServiceTests()
        {
            photoRepository = new Mock<IPhotoRepository>();

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
            photoRepository.Setup(p => p.GetAllPhotos()).ReturnsAsync(photoList);
            var service = new PhotoGalleryService(mapper, photoRepository.Object);

            // Act
            var result = service.GetAllPhotosGallery();

            // Assert
            var viewResult = Assert.IsType<Task<List<PhotoGallery>>>(result);
            Assert.NotNull(result.Result);
            Assert.Equal(photoList.Count, result.Result.Count);
        }

        //public async Task<List<PhotoGallery>> GetGalleryByFilmId(int id)
        //{
        //    return _mapper.Map<List<Photo>, List<PhotoGallery>>(await _photoRepository.GetGalleryByFilmId(id));
        //}

        [Fact]
        public void GetByFilmId()
        {
            // Arrange
            int filmId = 2;
            photoRepository.Setup(p => p.GetGalleryByFilmId(filmId)).ReturnsAsync(photoList);
            var service = new PhotoGalleryService(mapper, photoRepository.Object);

            // Act
            var result = service.GetGalleryByFilmId(filmId);

            // Assert
            var viewResult = Assert.IsType<Task<List<PhotoGallery>>>(result);
            Assert.NotNull(result.Result);
            Assert.Equal(photoList.Count, result.Result.Count);
            Assert.Equal(photoOneFilm[0].Src, result.Result[0].Src);
        }

        private List<Photo> photoList = new List<Photo>()
        {
            new Photo{ Id=1, FilmId=2, Src="testtttt" },
                 new Photo{ Id=2, FilmId=2, Src="tefrret" },
                      new Photo{ Id=3, FilmId=1, Src="testt5434ttt" },
                           new Photo{ Id=4, FilmId=4, Src="testttt435t" },
                                new Photo{ Id=5, FilmId=2, Src="te3453sttttt" },
        };

        private List<Photo> photoOneFilm = new List<Photo>()
        {
            new Photo{ Id=1, FilmId=2, Src="testtttt" },
                 new Photo{ Id=2, FilmId=2, Src="tefrret" },
                      new Photo{ Id=3, FilmId=2, Src="testt5434ttt" },
        };
    }
}
