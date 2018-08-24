using FilmsCatalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmsCatalog.DAL.Interfaces
{
   public interface IPhotoRepository
    {
        Task<List<Photo>> GetAllPhotos();
        Task<List<Photo>> GetGalleryByFilmId(int id);
        Task<Photo> DeletePhoto(Photo photo);
    }
}
