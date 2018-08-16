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
        private readonly RestClient _restClient;
        public StarsService()
        {
            this._restClient = new RestClient(url);
        }
        public async Task<StarsResultWithNext> GetAllStarsAsync()
        {
            RestRequest restRequest = new RestRequest(Method.GET);
            StarsResultWithNext result = new StarsResultWithNext();
            while (true)
            {
                StarsResultWithNext starsOnePage = await _restClient.GetTaskAsync<StarsResultWithNext>(restRequest);
                result.Results.AddRange(starsOnePage.Results);
                if (starsOnePage.Next != null) restRequest = new RestRequest(starsOnePage.Next,Method.GET);
                else break;
            }
            result.Count = result.Results.Count();
            setIndex(result);
            return result;
        }

        public async Task<StarsResultWithNext> GetStarsAsync()
        {
            RestRequest restRequest = new RestRequest(Method.GET);
            StarsResultWithNext result = await _restClient.GetTaskAsync<StarsResultWithNext>(restRequest);
            setIndex(result);
            return result;
        }

        public StarsResultWithNext GetStarsSync()
        {
            RestRequest restRequest = new RestRequest(Method.GET);
            StarsResultWithNext result = _restClient.Execute<StarsResultWithNext>(restRequest).Data;
            setIndex(result);
            return result;
        }
        private void setIndex(StarsResultWithNext starsRes, int startIndex = 0)
        {
            for (int i = startIndex; i < starsRes.Results.Count; i++)
            {
                starsRes.Results[i].Index = i + 1;
            }
        }
    }
}
