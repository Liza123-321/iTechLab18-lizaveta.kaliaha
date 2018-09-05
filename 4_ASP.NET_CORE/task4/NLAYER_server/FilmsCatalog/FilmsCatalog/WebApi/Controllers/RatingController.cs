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
    public class RatingController : UserBaseController
    {
        private readonly IRatingService _ratingService;
        private readonly IMapper _mapper;
        public RatingController(IRatingService ratingService, IMapper mapper, IUserService userService) : base(userService)
        {
            this._ratingService = ratingService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Models.Rating>> Get()
        {
            return _mapper.Map<List<FilmsCatalog.Business.Models.Rating>,List<Models.Rating>>(await _ratingService.GetAllRatings());
        }

        [HttpGet("{id}")]
        public async Task<double> Get(int id)
        {
            return _ratingService.GetAverageFilmRating(await _ratingService.GetRatingByFilmId(id));
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddRating([FromBody] Models.Rating model)
        {
            if (ModelState.IsValid) {
                return Ok(await _ratingService.SetRating(_mapper.Map<Models.Rating, FilmsCatalog.Business.Models.Rating>(model), UserId));
            }
           else return BadRequest();
        }
    }
}