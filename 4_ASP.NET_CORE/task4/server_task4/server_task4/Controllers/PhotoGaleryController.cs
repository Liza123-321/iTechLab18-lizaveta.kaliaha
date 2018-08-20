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
    public class PhotoGaleryController : ControllerBase
    {
        private readonly IPhotoGaleryService _photosService;
        public PhotoGaleryController(IPhotoGaleryService photosService)
        {
            this._photosService = photosService;
        }

        [HttpGet]
        public async Task<List<PhotoGaleryDTO>> Get()
        {
            return await _photosService.GetAllPhotosGalery();
        }

        [HttpGet("{id}")]
        public async Task<List<PhotoGaleryDTO>> Get(int id)
        {
            return await _photosService.GetGaleryByFilmId(id);
        }
    }
}
