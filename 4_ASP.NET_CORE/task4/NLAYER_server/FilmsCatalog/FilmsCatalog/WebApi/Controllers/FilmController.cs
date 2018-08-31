using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Models;
using FilmsCtalog.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmsCtalog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;
        private readonly IMapper _mapper;
        public FilmController(IFilmService filmService, IMapper mapper)
        {
            this._filmService = filmService;
            this._mapper = mapper;
        }

        // GET: api/Film
        [HttpGet]
        public async Task<List<Models.Film>> Get()
        {
            return _mapper.Map<List<FilmsCatalog.Business.Models.Film>, List<Models.Film>>(await _filmService.GetAllFilms());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Film>> GetWithGenres(int id)
        {
            Models.FilmWithGenres film = _mapper.Map<FilmsCatalog.Business.Models.FilmWithGenres, Models.FilmWithGenres>(await _filmService.GetFilmByWithGenres(id));
            if (film == null) return BadRequest(new { message = "Film with this id {" + id + "} not found" });
            return Ok(film);
        }

        // POST: api/Film
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Models.Film film)
        {
            return Ok(await _filmService.CreateFilm(_mapper.Map <Models.Film, FilmsCatalog.Business.Models.Film> (film)));
        }

        // PUT: api/Film/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Models.Film film)
        {
            var getfilm = await _filmService.UpdateFilm(_mapper.Map<Models.Film, FilmsCatalog.Business.Models.Film>(film));
            if (getfilm == null) return BadRequest("Film with this id {" + film.Id + "} not found");
            return Ok(getfilm);
        }
    }
}