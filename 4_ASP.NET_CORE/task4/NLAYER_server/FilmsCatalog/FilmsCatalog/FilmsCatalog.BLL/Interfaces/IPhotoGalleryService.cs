using FilmsCatalog.BLL.ModelsBLL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmsCatalog.BLL.Interfaces
{
    public interface IPhotoGalleryService
    {
        Task<List<PhotoGallery>> GetAllPhotosGallery();
        Task<List<PhotoGallery>> GetGalleryByFilmId(int id);
    }
}
