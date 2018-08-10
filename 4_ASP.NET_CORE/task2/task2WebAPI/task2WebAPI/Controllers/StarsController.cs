using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using task2WebAPI.Models;
using Newtonsoft.Json;
using task2WebAPI.Services;

namespace task2WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarsController : ControllerBase
    {
        private readonly IStarsService _starsService;
        public StarsController(IStarsService starsService)
        {
            this._starsService = starsService;
        }
        // GET api/stars/sync
        [HttpGet("{sync}")]
        public ActionResult GetSync()
        {
            string url = "https://swapi.co/api/starships/";
            return new ObjectResult(_starsService.GetStarsSync(url));

        }
        // GET api/stars
        [HttpGet("{async}")]
        public async Task<ActionResult> GetAsync()
        {
            string url = "https://swapi.co/api/starships/";
            return new ObjectResult(await _starsService.GetStarsAsync(url));

        }
        // GET api/stars
        [HttpGet("async/all")]
        public async Task<ActionResult> GetAsyncAll()
        {

            string url = "https://swapi.co/api/starships/";
            return new ObjectResult(await _starsService.GetAllStarsAsync(url));
        }
    }
    
}
