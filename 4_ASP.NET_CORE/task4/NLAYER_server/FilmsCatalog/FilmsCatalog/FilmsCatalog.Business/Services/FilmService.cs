using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Models;
using FilmsCatalog.DAL.Interfaces;
using FilmsCatalog.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsCatalog.Business.Services
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

        public async Task<FilmModel> CreateFilm(FilmModel film)
        {        
            return _mapper.Map < Film, FilmModel > (await _filmRepository.CreateFilm(_mapper.Map<FilmModel, Film>(film)));
        }
        private async Task<FilmModel> SetFilmRating(FilmModel film)
        {
            if (film == null) return null;
            film.AverageRating = _ratingService.GetAverageFilmRating(await _ratingService.GetRatingByFilmId(film.Id));
            return film;
        }
        private async Task<List<FilmModel>> SetFilmsRating(List<FilmModel> films)
        {
            for (int i = 0; i < films.Count; i++)
            {
                films[i].AverageRating = _ratingService.GetAverageFilmRating(await _ratingService.GetRatingByFilmId(films[i].Id));
            }
            return films;
        }
        public async Task<List<FilmModel>> GetAllFilms()
        {
            return await SetFilmsRating(_mapper.Map<List<Film>, List<FilmModel>>(await _filmRepository.GetAllFilms()));
        }

        public async Task<FilmModel> GetFilmById(int id)
        {
            return await SetFilmRating(_mapper.Map<Film,FilmModel>(await _filmRepository.GetFilmById(id)));
        }

        public async Task<FilmModel> UpdateFilm(FilmModel film)
        {
            return _mapper.Map<Film, FilmModel>(await _filmRepository.UpdateFilm(_mapper.Map<FilmModel, Film>(film)));
        }
    }
}
