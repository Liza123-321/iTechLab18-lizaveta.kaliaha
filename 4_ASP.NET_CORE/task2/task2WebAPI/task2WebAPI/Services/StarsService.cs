using AutoMapper;
using Newtonsoft.Json;
using RestSharp;
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
        private readonly IMapper _mapper;
        public StarsService(IMapper mapper)
        {
            this._mapper = mapper;
        }
        public async Task<StarsResult> GetAllStarsAsync()
        {
            StarsResultWithNext result = new StarsResultWithNext();
                int count = 0;
                string currentUrl = url;
                var req = new RestRequest(Method.GET);
                var client = new RestClient(currentUrl);
                StarsResultWithNext starsOnePage = null;
                while (currentUrl != null)
                {
                    var responseStarsList = new TaskCompletionSource<string>();
                    client.ExecuteAsync(req, (response) =>
                    {
                        responseStarsList.SetResult(response.Content);
                    });
                    starsOnePage =  JsonConvert.DeserializeObject<StarsResultWithNext>(responseStarsList.Task.Result);
                    for (int j = 0; j < starsOnePage.Results.Count; j++)
                    {
                        count++;
                        starsOnePage.Results[j].Index = count;
                    }
                    result.Results.AddRange(starsOnePage.Results);
                    currentUrl = starsOnePage.Next;
                    if (currentUrl != null) client = new RestClient(currentUrl);
                    else break;
                }
                result.Count = count;
            return _mapper.Map<StarsResultWithNext,StarsResult> (result);
        }

        public async Task<StarsResult> GetStarsAsync()
        {
            var client = new RestClient(url);
            var req = new RestRequest(Method.GET);
            StarsResult result = null;
                var responseStarsList = new TaskCompletionSource<string>();
                client.ExecuteAsync(req,(response)=>
                {
                   responseStarsList.SetResult(response.Content);
                } );
                result = JsonConvert.DeserializeObject<StarsResult>(responseStarsList.Task.Result);
                for (int i = 0; i < result.Results.Count; i++)
                {
                    result.Results[i].Index = i + 1;
                }    
            return result;
        }

        public StarsResult GetStarsSync()
        {
            StarsResult result = null;
            var client = new RestClient(url);
            var req = new RestRequest(Method.GET);
                var responseStarsList = client.Execute(req);
                result = JsonConvert.DeserializeObject<StarsResult>(responseStarsList.Content);
                for (int i = 0; i < result.Results.Count; i++)
                {
                    result.Results[i].Index = i + 1;
                }
            return result;
        }
    }
}
