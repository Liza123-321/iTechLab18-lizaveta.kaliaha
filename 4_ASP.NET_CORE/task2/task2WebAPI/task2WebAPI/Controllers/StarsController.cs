using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using task2WebAPI.Models;
using Newtonsoft.Json;

namespace task2WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarsController : ControllerBase
    {
        // GET api/stars/sync
        [HttpGet("{sync}")]
        public ActionResult GetSync()
        {
            string url = "https://swapi.co/api/starships/";
            using (var webClient = new WebClient())
            {
                var response = webClient.DownloadString(url);
                ResStars result = JsonConvert.DeserializeObject<ResStars>(response);
                for (int i = 0; i < result.Results.Count; i++)
                {
                    result.Results[i].Index = i + 1;
                }
                return new ObjectResult(result);
            }

        }
        // GET api/stars
        [HttpGet("{async}")]
        public async Task<ActionResult> GetAsync()
        {
            string url = "https://swapi.co/api/starships/";
            using (var webClient = new WebClient())
            {
                string response = await webClient.DownloadStringTaskAsync(url);
                ResStars result = JsonConvert.DeserializeObject<ResStars>(response);
                for (int i = 0; i < result.Results.Count; i++)
                {
                    result.Results[i].Index = i + 1;
                }
                return new ObjectResult(result);
            }

        }
        // GET api/stars
        [HttpGet("async/all")]
        public async Task<ActionResult> GetAsyncAll()
        {
            string url = "https://swapi.co/api/starships/";
            using (var webClient = new WebClient())
            {
                int count = 0;
                ResStars res =new ResStars();
                while (url != null)
                {
                    string response = await webClient.DownloadStringTaskAsync(url);
                    ResStarsNext result = JsonConvert.DeserializeObject<ResStarsNext>(response);
                    url = result.Next;
                    for (int j = 0; j < result.Results.Count; j++)
                    {
                        count++;
                        result.Results[j].Index = count;
                    }
                    res.Results.AddRange(result.Results);
                }
                res.Count = count;
                return new ObjectResult(res);
            }
        }
    }
    
}
