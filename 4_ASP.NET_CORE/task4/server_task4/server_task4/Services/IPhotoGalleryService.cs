using server_task4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_task4.Services
{
    public interface IPhotoGalleryService
    {
            Task<List<PhotoGalleryDTO>> GetAllPhotosGallery();
            Task<List<PhotoGalleryDTO>> GetGalleryByFilmId(int id);
            Task<List<PhotoGalleryDTO>> DeleteGalleryByFilmId(int id);
    }
}
