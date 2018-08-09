using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using task1WebAPI.Models;

namespace task1WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get(int? a, int? b)
        {
            if (a == null || b == null) return new ObjectResult("Error: Params Not Found");
            SumObject res = new SumObject { A = a, B = b, Sum = (int)(a + b) };
            if (a <= 0) return new ObjectResult("Error: a must be >0");
            if (b >= 0) return new ObjectResult("Error: b must be <0");
            return new ObjectResult(res);
        }
        // GET api/values//
        //[HttpGet("{a:int:min(1)}/{b:int:max(-1)}")]
        //public ActionResult Get(int a, int b)
        //{
        //    var res = new { a = a, b = b, sum = (a + b) };
        //    return new ObjectResult(res);
        //}

    }
}
