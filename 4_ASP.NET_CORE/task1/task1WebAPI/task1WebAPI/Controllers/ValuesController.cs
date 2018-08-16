using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using task1WebAPI.Models;
using task1WebAPI.Services;

namespace task1WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly ISumService _sumService;
        public ValuesController(ISumService sumService)
        {
            this._sumService = sumService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult Get(DataModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok(_sumService.Sum(model));
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
    }
}
