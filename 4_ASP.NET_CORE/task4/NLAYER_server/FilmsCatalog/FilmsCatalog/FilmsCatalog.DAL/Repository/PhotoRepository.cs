using FilmsCatalog.DAL.Context;
using FilmsCatalog.DAL.Interfaces;
using FilmsCatalog.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<List<Photo>> GetAllPhotos()
        {
            return await db.Photos.ToListAsync();
        }

        public async Task<List<Photo>> GetGalleryByFilmId(int id)
        {
            return await db.Photos.Where(x => x.FilmId == id).ToListAsync();
        }
    }
}
