using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using task1WebAPI.Models;

namespace task1WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult Get(DataModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok(new SumModel { A = (int)model.A, B =(int)model.B, Sum = (int)(model.A + model.B) });
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
    }
}
