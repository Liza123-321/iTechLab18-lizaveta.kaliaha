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
        public async Task<List<FilmViewModel>> Get()
        {
            return _mapper.Map<List<FilmModel>, List<FilmViewModel>>(await _filmService.GetAllFilms());
        }

        // GET: api/Film/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            FilmViewModel film = _mapper.Map<FilmModel,FilmViewModel>(await _filmService.GetFilmById(id));
            if (film == null) return BadRequest(new { message = "Film with this id {" + id + "} not found" });
            return Ok(film);
        }

        // POST: api/Film
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]FilmViewModel film)
        {
            return Ok(await _filmService.CreateFilm(_mapper.Map <FilmViewModel, FilmModel> (film)));
        }

        // PUT: api/Film/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody]FilmViewModel film)
        {
            var getfilm = await _filmService.UpdateFilm(_mapper.Map<FilmViewModel, FilmModel>(film));
            if (getfilm == null) return BadRequest("Film with this id {" + film.Id + "} not found");
            return Ok(getfilm);
        }
    }
}