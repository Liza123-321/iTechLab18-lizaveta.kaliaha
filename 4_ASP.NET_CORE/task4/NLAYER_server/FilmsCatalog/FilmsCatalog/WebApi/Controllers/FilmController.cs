using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmsCatalog.BLL.Interfaces;
using FilmsCatalog.BLL.ModelsBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmsCtalog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;
        public FilmController(IFilmService filmService)
        {
            this._filmService = filmService;
        }

        // GET: api/Film
        [HttpGet]
        public async Task<List<FilmBLL>> Get()
        {
            return await _filmService.GetAllFilms();
        }

        // GET: api/Film/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var film = await _filmService.GetFilmById(id);
            if (film == null) return BadRequest(new { message = "Film with this id {" + id + "} not found" });
            return Ok(film);
        }

        // POST: api/Film
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]FilmBLL film)
        {
            return Ok(await _filmService.CreateFilm(film));
        }

        // PUT: api/Film/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody]FilmBLL film)
        {
            var getfilm = await _filmService.UpdateFilm(film);
            if (getfilm == null) return BadRequest("Film with this id {" + film.Id + "} not found");
            return Ok(getfilm);
        }
    }
}