using FilmsCatalog.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsCatalog.Business.Interfaces
{
    public interface IPhotoGalleryService
    {
        Task<IList<PhotoGallery>> GetAllPhotosGallery();
        Task<IList<PhotoGallery>> GetGalleryByFilmId(int id);
    }
}
