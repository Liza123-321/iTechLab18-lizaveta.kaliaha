using FilmsCatalog.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmsCatalog.Business.Interfaces
{
    public interface IPhotoGalleryService
    {
        Task<List<PhotoGalleryModel>> GetAllPhotosGallery();
        Task<List<PhotoGalleryModel>> GetGalleryByFilmId(int id);
    }
}
