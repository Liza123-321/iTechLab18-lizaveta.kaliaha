using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmsCatalog.BLL.Interfaces;
using FilmsCatalog.BLL.ModelsBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmsCtalog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoGalleryController : ControllerBase
    {
        private readonly IPhotoGalleryService _photosService;
        public PhotoGalleryController(IPhotoGalleryService photosService)
        {
            this._photosService = photosService;
        }

        [HttpGet]
        public async Task<List<PhotoGallery>> Get()
        {
            return await _photosService.GetAllPhotosGallery();
        }

        [HttpGet("{id}")]
        public async Task<List<PhotoGallery>> Get(int id)
        {
            return await _photosService.GetGalleryByFilmId(id);
        }
    }
}