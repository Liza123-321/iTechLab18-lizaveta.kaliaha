using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Models;
using FilmsCtalog.WebApi.HttpBase;
using FilmsCtalog.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmsCtalog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;
        private readonly IMapper _mapper;
        public RatingController(IRatingService ratingService, IMapper mapper)
        {
            this._ratingService = ratingService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<List<RatingViewModel>> Get()
        {
            return _mapper.Map<List<RatingModel>,List<RatingViewModel>>(await _ratingService.GetAllRatings());
        }

        [HttpGet("{id}")]
        public async Task<double> Get(int id)
        {
            return _ratingService.GetAverageFilmRating(await _ratingService.GetRatingByFilmId(id));
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddRating([FromBody]RatingViewModel model)
        {
            if (ModelState.IsValid) {
                var myRating = await _ratingService.SetRating(_mapper.Map<RatingViewModel, RatingModel>(model), Int32.Parse(HttpContext.GetUserIdAsync()));
                return Ok(myRating);
            }
           else return BadRequest();
        }
    }
}