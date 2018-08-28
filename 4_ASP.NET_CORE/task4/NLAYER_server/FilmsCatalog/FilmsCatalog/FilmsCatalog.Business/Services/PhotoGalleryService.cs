using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Models;
using FilmsCatalog.DAL.Interfaces;
using FilmsCatalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<List<PhotoGalleryModel>> GetAllPhotosGallery()
        {
            return _mapper.Map<List<Photo>, List<PhotoGalleryModel>>(await _photoRepository.GetAllPhotos());
        }

        public async Task<List<PhotoGalleryModel>> GetGalleryByFilmId(int id)
        {
            return _mapper.Map<List<Photo>, List<PhotoGalleryModel>>(await _photoRepository.GetGalleryByFilmId(id));
        }
    }
}
