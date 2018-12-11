using FilmsCatalog.Business.Interfaces;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCtalog.WebApi.Controllers
{
    [Route("[controller]")]
    public class ODataQueriesController : ODataController
    {
        private readonly IODataService _oDataService;

        public ODataQueriesController(IODataService oDataService)
        {
            _oDataService = oDataService;
        }

        [EnableQuery]
        [Route("GetFilms")]
        public IActionResult GetFilms()
        {
            return Ok(_oDataService.GetQueryableFilms());
        }


        [EnableQuery]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            return Ok(_oDataService.GetQueryableUsers());
        }

        [EnableQuery]
        [Route("GetPhotos")]
        public IActionResult GetPhotos()
        {
            return Ok(_oDataService.GetQueryablePhotos());
        }

        [EnableQuery]
        [Route("GetComments")]
        public IActionResult GetComments()
        {
            return Ok(_oDataService.GetQueryableComments());
        }

        [EnableQuery]
        [Route("GetRatings")]
        public IActionResult GetRatings()
        {
            return Ok(_oDataService.GetQueryableRatings());
        }

        [EnableQuery]
        [Route("GetGenres")]
        public IActionResult GetGenres()
        {
            return Ok(_oDataService.GetQueryableGenres());
        }

    }
}
