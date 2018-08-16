using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task3WebAPI.Context;
using task3WebAPI.Filters;
using task3WebAPI.Models;
using task3WebAPI.Services;
namespace task3WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmsService _filmsService;

        public FilmsController(IFilmsService filmsService)
        {
            this._filmsService = filmsService;

        }
        // GET api/films
        [HttpGet]
        public async Task<IEnumerable<FilmModel>> Get()
        {
            return await _filmsService.GetAllFilms();
        }
        // GET: api/films/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var film = await  _filmsService.GetFilmById(id);
            if (film == null) return BadRequest(new { message = "Film with this id {" + id + "} not found" });
            return Ok(film);
        }
        // POST: api/films
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]FilmModel film)
        {
            return Ok(await _filmsService.CreateFilm(film));
        }
        // PUT: api/films/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]FilmModel film)
        {
            var getfilm = await _filmsService.UpdateFilm(film);
            if (getfilm == null) return BadRequest("Film with this id {" + film.Id + "} not found");
            return Ok(getfilm);
        }

        // DELETE: api/films/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var film = await _filmsService.DeleteFilm(id);
            if (film == null) return BadRequest(new { message="Film with this id {" + id + "} not found" });
            return Ok(film);
        }
    }
}
