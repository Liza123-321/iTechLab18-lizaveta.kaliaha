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
        private string url = "https://swapi.co/api/starships/";
        public StarsController(IStarsService starsService)
        {
            this._starsService = starsService;
        }
        // GET api/stars/sync
        [HttpGet("{sync}")]
        public ActionResult GetSync()
        {
            return new ObjectResult(_starsService.GetStarsSync(url));

        }
        // GET api/stars/async
        [HttpGet("{async}")]
        public async Task<ActionResult> GetAsync()
        {
            return new ObjectResult(await _starsService.GetStarsAsync(url));

        }
        // GET api/stars/async/all
        [HttpGet("async/all")]
        public async Task<ActionResult> GetAsyncAll()
        {

            return new ObjectResult(await _starsService.GetAllStarsAsync(url));
        }
    }
    
}
