using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Models;
using FilmsCatalog.DAL.Interfaces;
using FilmsCatalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmsCatalog.Business.Services
{
    public class GenreService : IGenreService
    {
        private readonly IMapper _mapper;
        private IGenreRepository _genreRepository;

        public GenreService(IMapper mapper, IGenreRepository genreRepository)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
        }

        public async  Task<IList<Models.Genre>> GetAllGenres()
        {
            return _mapper.Map<IList<DAL.Models.Genre>, IList<Models.Genre>>(await _genreRepository.GetAllGenres());
        }
       public async Task<GenreWithFilm> GetGenreByNameWithFilms(string name)
        {
            return _mapper.Map<DAL.Models.Genre, GenreWithFilm>(await _genreRepository.GetGenreByNameWithFilms(name));
        }
    }
}
