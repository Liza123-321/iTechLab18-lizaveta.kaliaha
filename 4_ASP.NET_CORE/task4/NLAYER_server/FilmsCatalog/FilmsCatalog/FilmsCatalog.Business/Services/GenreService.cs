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

        public async  Task<List<GenreModel>> GetAllGenres()
        {
            return _mapper.Map<List<Genre>, List<GenreModel>>(await _genreRepository.GetAllGenres());
        }
    }
}
