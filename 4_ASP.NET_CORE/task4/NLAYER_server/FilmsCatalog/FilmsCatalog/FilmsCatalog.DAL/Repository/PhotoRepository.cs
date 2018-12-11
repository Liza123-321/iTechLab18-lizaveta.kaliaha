using FilmsCatalog.DAL.Context;
using FilmsCatalog.DAL.Interfaces;
using FilmsCatalog.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.DAL.Repository
{
    public class PhotoRepository : IPhotoRepository
    {
        private ApplicationContext db;

        public PhotoRepository(ApplicationContext photos)
        {
            this.db = photos;
        }

        public async Task<Photo> DeletePhoto(Photo photo)
        {
            db.Photos.Remove(photo);
            await db.SaveChangesAsync();
            return photo;
        }

        public async Task<IList<Photo>> GetAllPhotos()
        {
            return await db.Photos.ToListAsync();
        }

        public IQueryable<Photo> GetQueryableAllPhotos()
        {
            return db.Photos;
        }

        public async Task<IList<Photo>> GetGalleryByFilmId(int id)
        {
            return await db.Photos.Where(x => x.FilmId == id).ToListAsync();
        }
    }
}
