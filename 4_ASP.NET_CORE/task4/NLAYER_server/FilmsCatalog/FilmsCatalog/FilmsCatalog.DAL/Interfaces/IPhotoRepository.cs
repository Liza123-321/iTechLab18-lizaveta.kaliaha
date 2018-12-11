using FilmsCatalog.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.DAL.Interfaces
{
   public interface IPhotoRepository
    {
        Task<IList<Photo>> GetAllPhotos();
        IQueryable<Photo> GetQueryableAllPhotos();
        Task<IList<Photo>> GetGalleryByFilmId(int id);
        Task<Photo> DeletePhoto(Photo photo);
    }
}
