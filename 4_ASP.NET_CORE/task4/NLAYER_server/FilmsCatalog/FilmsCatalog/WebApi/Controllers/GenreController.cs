using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Models;
using FilmsCtalog.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmsCtalog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenreController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Models.Genre>> Get()
        {
            return _mapper.Map<List<FilmsCatalog.Business.Models.Genre>, List<Models.Genre>>(await _genreService.GetAllGenres());
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Models.GenreWithFilm>> GetWithFilms(string name)
        {
            Models.GenreWithFilm genre = _mapper.Map<FilmsCatalog.Business.Models.GenreWithFilm, Models.GenreWithFilm>(await _genreService.GetGenreByNameWithFilms(name));
            if (genre == null) return BadRequest(new { message = "Genre with this name {" + name + "} not found" });
            return Ok(genre);
        }
    }
}