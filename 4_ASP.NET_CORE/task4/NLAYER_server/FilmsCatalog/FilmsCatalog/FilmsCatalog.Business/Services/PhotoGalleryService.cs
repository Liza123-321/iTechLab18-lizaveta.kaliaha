using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Models;
using FilmsCatalog.DAL.Interfaces;
using FilmsCatalog.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsCatalog.Business.Services
{
    public class PhotoGalleryService : IPhotoGalleryService
    {
        private readonly IMapper _mapper;
        private IPhotoRepository _photoRepository;

        public PhotoGalleryService(IMapper mapper, IPhotoRepository photoRepository)
        {
            _mapper = mapper;
            _photoRepository = photoRepository;
        }

        public async Task<List<PhotoGallery>> GetAllPhotosGallery()
        {
            return _mapper.Map<List<Photo>, List<PhotoGallery>>(await _photoRepository.GetAllPhotos());
        }

        public async Task<List<PhotoGallery>> GetGalleryByFilmId(int id)
        {
            return _mapper.Map<List<Photo>, List<PhotoGallery>>(await _photoRepository.GetGalleryByFilmId(id));
        }
    }
}
