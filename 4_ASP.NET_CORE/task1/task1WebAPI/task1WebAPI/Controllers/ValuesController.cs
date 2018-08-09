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
        public ActionResult Get(SumModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok(new SumModel { A = model.A, B = model.B, Sum = (int)(model.A + model.B) });
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
        // GET api/values//
        //[HttpGet("{a:int:min(1)}/{b:int:max(-1)}")]
        //public ActionResult Get(int a, int b)
        //{
        //    SumObject res = new SumObject { A = a, B = b, Sum = (int)(a + b) };
        //    return new ObjectResult(res);
        //}

    }
}
