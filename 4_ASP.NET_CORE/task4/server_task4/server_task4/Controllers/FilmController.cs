using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_task4.DAL.Models;
using server_task4.Services;

namespace server_task4.Controllers
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
        public async Task<List<Film>> Get()
        {
            return await _filmService.GetAllFilms();
        }

        // GET: api/Film/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Film
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Film/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
