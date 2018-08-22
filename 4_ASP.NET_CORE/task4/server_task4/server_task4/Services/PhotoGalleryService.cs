using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using server_task4.DAL.Context;
using server_task4.DAL.Models;
using server_task4.Models;

namespace server_task4.Services
{
    public class PhotoGalleryService : IPhotoGalleryService
    {
        private dbContext db;
        private readonly IMapper _mapper;
        public PhotoGalleryService(dbContext photos, IMapper mapper)
        {
            this._mapper = mapper;
            this.db = photos;
        }
        public async  Task<List<PhotoGalleryDTO>> DeleteGalleryByFilmId(int id)
        {
            List<Photo> photos = await db.Photos.Where(x => x.FilmId == id).ToListAsync();
            if (photos == null)
            {
                return null;
            }
            db.Photos.RemoveRange(photos);
            await db.SaveChangesAsync();
            return _mapper.Map<List<Photo>, List<PhotoGalleryDTO>>(photos);
        }

        public async Task<List<PhotoGalleryDTO>> GetAllPhotosGallery()
        {
            return _mapper.Map<List<Photo>,List<PhotoGalleryDTO>>(await db.Photos.ToListAsync());
        }

        public async Task<List<PhotoGalleryDTO>> GetGalleryByFilmId(int id)
        {
            return _mapper.Map<List<Photo>, List<PhotoGalleryDTO>>(await (db.Photos.Where(x => x.FilmId == id).ToListAsync()));
        }
    }
}
