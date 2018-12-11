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

        public async Task<IList<PhotoGallery>> GetAllPhotosGallery()
        {
            return _mapper.Map<IList<Photo>, IList<PhotoGallery>>(await _photoRepository.GetAllPhotos());
        }

        public async Task<IList<PhotoGallery>> GetGalleryByFilmId(int id)
        {
            return _mapper.Map<IList<Photo>, IList<PhotoGallery>>(await _photoRepository.GetGalleryByFilmId(id));
        }
    }
}
