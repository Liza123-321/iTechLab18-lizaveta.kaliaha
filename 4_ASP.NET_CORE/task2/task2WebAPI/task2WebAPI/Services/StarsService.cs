using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using task2WebAPI.Models;

namespace task2WebAPI.Services
{
    public class StarsService : IStarsService
    {
       private const string url = "https://swapi.co/api/starships/";
        public async Task<StarsResult> GetAllStarsAsync()
        {
            StarsResult result = new StarsResult();
            using (var webClient = new WebClient())
            {
                int count = 0;
                string currentUrl = url;
                while (currentUrl != null)
                {
                    string responseStarsList = await webClient.DownloadStringTaskAsync(currentUrl);
                    StarsResultWithNext starsOnePage = JsonConvert.DeserializeObject<StarsResultWithNext>(responseStarsList);
                    currentUrl = starsOnePage.Next;
                    for (int j = 0; j < starsOnePage.Results.Count; j++)
                    {
                        count++;
                        starsOnePage.Results[j].Index = count;
                    }
                    result.Results.AddRange(starsOnePage.Results);
                }
                result.Count = count;
            }
            return result;
        }

        public async Task<StarsResult> GetStarsAsync()
        {
            StarsResult result = null;
            using (var webClient = new WebClient())
            {
                string responseStarsList = await webClient.DownloadStringTaskAsync(url);
                result = JsonConvert.DeserializeObject<StarsResult>(responseStarsList);
                for (int i = 0; i < result.Results.Count; i++)
                {
                    result.Results[i].Index = i + 1;
                }    
            }
            return result;
        }

        public StarsResult GetStarsSync()
        {
            StarsResult result = null;
            using (var webClient = new WebClient())
            {
                var responseStarsList = webClient.DownloadString(url);
                result = JsonConvert.DeserializeObject<StarsResult>(responseStarsList);
                for (int i = 0; i < result.Results.Count; i++)
                {
                    result.Results[i].Index = i + 1;
                }
            }
            return result;
        }
    }
}
