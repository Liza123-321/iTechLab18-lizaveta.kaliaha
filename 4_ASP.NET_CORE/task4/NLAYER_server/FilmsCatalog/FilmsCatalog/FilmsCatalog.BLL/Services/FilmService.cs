using AutoMapper;
using FilmsCatalog.BLL.Interfaces;
using FilmsCatalog.BLL.ModelsBLL;
using FilmsCatalog.DAL.Interfaces;
using FilmsCatalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmsCatalog.BLL.Services
{
    public class FilmService : IFilmService
    {
        private IFilmRepository _filmRepository;
        private readonly IMapper _mapper;
        private readonly IRatingService _ratingService;

        public FilmService(IFilmRepository filmRepository, IMapper mapper, IRatingService ratingService)
        {
            this._mapper = mapper;
            this._filmRepository = filmRepository;
            this._ratingService = ratingService;
        }

        public async Task<FilmBLL> CreateFilm(FilmBLL film)
        {        
            return _mapper.Map < Film, FilmBLL > (await _filmRepository.CreateFilm(_mapper.Map<FilmBLL, Film>(film)));
        }
        private async Task<FilmBLL> SetFilmRating(FilmBLL film)
        {
            film.AverageRating = _ratingService.GetAverageFilmRating(await _ratingService.GetRatingByFilmId(film.Id));
            return film;
        }
        private async Task<List<FilmBLL>> SetFilmsRating(List<FilmBLL> films)
        {
            for (int i = 0; i < films.Count; i++)
            {
                films[i].AverageRating = _ratingService.GetAverageFilmRating(await _ratingService.GetRatingByFilmId(films[i].Id));
            }
            return films;
        }
        public async Task<List<FilmBLL>> GetAllFilms()
        {
            return await SetFilmsRating(_mapper.Map<List<Film>, List<FilmBLL>>(await _filmRepository.GetAllFilms()));
        }

        public async Task<FilmBLL> GetFilmById(int id)
        {
            return await SetFilmRating(_mapper.Map<Film,FilmBLL>(await _filmRepository.GetFilmById(id)));
        }

        public async Task<FilmBLL> UpdateFilm(FilmBLL film)
        {
            return _mapper.Map<Film, FilmBLL>(await _filmRepository.UpdateFilm(_mapper.Map<FilmBLL, Film>(film)));
        }
    }
}
