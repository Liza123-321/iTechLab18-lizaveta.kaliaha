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

        public async Task<Models.Film> CreateFilm(Models.Film film)
        {
            var createFilm = await _filmRepository.CreateFilm(_mapper.Map<Models.Film, DAL.Models.Film>(film));
            return _mapper.Map <DAL.Models.Film, Models.Film> (createFilm);
        }
        private async Task<Models.Film> SetFilmRating(Models.Film film)
        {
            if (film == null) return null;
            film.AverageRating = _ratingService.GetAverageFilmRating(await _ratingService.GetRatingByFilmId(film.Id));
            return film;
        }
        private async Task<FilmWithGenres> SetFilmRating(FilmWithGenres film)
        {
            if (film == null) return null;
            film.AverageRating = _ratingService.GetAverageFilmRating(await _ratingService.GetRatingByFilmId(film.Id));
            return film;
        }
        public async Task<FilmWithGenres> GetFilmByWithGenres(int id)
        {
            return await SetFilmRating(_mapper.Map<DAL.Models.Film, FilmWithGenres>(await _filmRepository.GetFilmByWithGenres(id)));
        }
        private async Task<List<Models.Film>> SetFilmsRating(List<Models.Film> films)
        {
            for (int i = 0; i < films.Count; i++)
            {
                films[i].AverageRating = _ratingService.GetAverageFilmRating(await _ratingService.GetRatingByFilmId(films[i].Id));
            }
            return films;
        }
        public async Task<List<Models.Film>> GetAllFilms()
        {
            return await SetFilmsRating(_mapper.Map<List<DAL.Models.Film>, List<Models.Film>>(await _filmRepository.GetAllFilms()));
        }

        public async Task<List<Models.Film>> GetAllFilmsLazy(int page, int pageSize)
        {
            return await SetFilmsRating(_mapper.Map<List<DAL.Models.Film>, List<Models.Film>>(await _filmRepository.GetAllFilmsLazy(page, pageSize)));
        }


        public async Task<Models.Film> GetFilmById(int id)
        {
            return await SetFilmRating(_mapper.Map<DAL.Models.Film, Models.Film>(await _filmRepository.GetFilmById(id)));
        }

        public async Task<Models.Film> UpdateFilm(Models.Film film)
        {
            return _mapper.Map<DAL.Models.Film, Models.Film>(await _filmRepository.UpdateFilm(_mapper.Map<Models.Film, DAL.Models.Film>(film)));
        }
    }
}
