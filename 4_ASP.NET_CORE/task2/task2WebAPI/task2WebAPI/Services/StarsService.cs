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
        public async Task<ResStars> GetAllStarsAsync(string url)
        {
            ResStars result = new ResStars();
            using (var webClient = new WebClient())
            {
                int count = 0;
                while (url != null)
                {
                    string responseStarsList = await webClient.DownloadStringTaskAsync(url);
                    ResStarsNext starsOnePage = JsonConvert.DeserializeObject<ResStarsNext>(responseStarsList);
                    url = starsOnePage.Next;
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

        public async Task<ResStars> GetStarsAsync(string url)
        {
            ResStars result = new ResStars();
            using (var webClient = new WebClient())
            {
                string responseStarsList = await webClient.DownloadStringTaskAsync(url);
                result = JsonConvert.DeserializeObject<ResStars>(responseStarsList);
                for (int i = 0; i < result.Results.Count; i++)
                {
                    result.Results[i].Index = i + 1;
                }    
            }
            return result;
        }

        public ResStars GetStarsSync(string url)
        {
            ResStars result = new ResStars();
            using (var webClient = new WebClient())
            {
                var responseStarsList = webClient.DownloadString(url);
                result = JsonConvert.DeserializeObject<ResStars>(responseStarsList);
                for (int i = 0; i < result.Results.Count; i++)
                {
                    result.Results[i].Index = i + 1;
                }
            }
            return result;
        }
    }
}
