using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Models;
using FilmsCtalog.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmsCtalog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoGalleryController : ControllerBase
    {
        private readonly IPhotoGalleryService _photosService;
        private readonly IMapper _mapper;
        public PhotoGalleryController(IPhotoGalleryService photosService, IMapper mapper)
        {
            this._photosService = photosService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<List<PhotoGalleryViewModel>> Get()
        {
            return _mapper.Map<List<PhotoGalleryModel>, List<PhotoGalleryViewModel>> (await _photosService.GetAllPhotosGallery());
        }

        [HttpGet("{id}")]
        public async Task<List<PhotoGalleryViewModel>> Get(int id)
        {
            return _mapper.Map<List<PhotoGalleryModel>, List<PhotoGalleryViewModel>>(await _photosService.GetGalleryByFilmId(id));
        }
    }
}