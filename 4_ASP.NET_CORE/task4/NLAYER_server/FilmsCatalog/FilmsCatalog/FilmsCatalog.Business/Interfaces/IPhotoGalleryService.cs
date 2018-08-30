using FilmsCatalog.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsCatalog.Business.Interfaces
{
    public interface IPhotoGalleryService
    {
        Task<List<PhotoGallery>> GetAllPhotosGallery();
        Task<List<PhotoGallery>> GetGalleryByFilmId(int id);
    }
}
