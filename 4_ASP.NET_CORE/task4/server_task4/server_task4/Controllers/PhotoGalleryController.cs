using Microsoft.AspNetCore.Mvc;
using server_task4.DAL.Models;
using server_task4.Models;
using server_task4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_task4.Controllers
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
        public async Task<List<PhotoGalleryDTO>> Get()
        {
            return await _photosService.GetAllPhotosGallery();
        }

        [HttpGet("{id}")]
        public async Task<List<PhotoGalleryDTO>> Get(int id)
        {
            return await _photosService.GetGalleryByFilmId(id);
        }
    }
}
