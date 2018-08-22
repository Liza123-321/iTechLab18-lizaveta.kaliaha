using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server_task4.Models;
using server_task4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_task4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;
        public RatingController(IRatingService ratingService)
        {
            this._ratingService = ratingService;
        }

        [HttpGet]
        public async Task<List<RatingDTO>> Get()
        {
            return await _ratingService.GetAllRatings();
        }

        [HttpGet("{id}")]
        public async Task<double> Get(int id)
        {
            return _ratingService.GetAverageFilmRating(await _ratingService.GetRatingByFilmId(id));
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddRating([FromBody]RatingDTO rating)
        {
            var myRating = await _ratingService.SetRating(rating, User.Identity.Name);
            if (myRating == null) return BadRequest(new { message = "BadRequest" });
            return Ok(myRating);

        }
    }
}
