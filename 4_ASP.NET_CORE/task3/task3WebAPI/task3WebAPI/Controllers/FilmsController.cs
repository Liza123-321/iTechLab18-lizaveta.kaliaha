using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task3WebAPI.Context;
using task3WebAPI.Models;
using task3WebAPI.Services;
namespace task3WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmsService _filmsService;
        private readonly ILog _logger= LogManager.GetLogger(AssemblyInfo.Info,"LOGGER");
        private readonly task3WebAPI.MyLogger.Logger _logcreater;
        public FilmsController(IFilmsService filmsService)
        {
            this._logcreater.InitLogger();
            this._filmsService = filmsService;
        }
        // GET api/films
        [HttpGet]
        public ActionResult<IEnumerable<FilmModel>> Get()
        {
            return _filmsService.getAllFilms();
        }
        // GET: api/films/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _logcreater.Log.Info("Ура заработало!");
            return new ObjectResult(_filmsService.getByIdFilm(id));
        }
        // POST: api/films
        [HttpPost]
        public IActionResult Post([FromBody]FilmModel film)
        {
            return Ok(_filmsService.createFilm(film));
        }
        // PUT: api/films/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]FilmModel film)
        {
            return Ok(_filmsService.updateFilm(id,film));
        }

        // DELETE: api/films/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_filmsService.deleteFilm(id));
        }
    }
}
