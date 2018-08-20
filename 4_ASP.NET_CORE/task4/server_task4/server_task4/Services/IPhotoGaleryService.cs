using server_task4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_task4.Services
{
    public interface IPhotoGaleryService
    {
            Task<List<PhotoGaleryDTO>> GetAllPhotosGalery();
            Task<List<PhotoGaleryDTO>> GetGaleryByFilmId(int id);
            Task<List<PhotoGaleryDTO>> DeleteGaleryByFilmId(int id);
    }
}
