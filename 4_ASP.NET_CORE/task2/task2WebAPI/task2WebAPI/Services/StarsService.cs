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
        private readonly RestRequest _restRequest;
        private readonly RestClient _restClient;
        public StarsService(IMapper mapper)
        {
            this._mapper = mapper;
            this._restRequest= new RestRequest(Method.GET);
            this._restClient = new RestClient(url);
        }
        public async Task<StarsResult> GetAllStarsAsync()
        {
            StarsResultWithNext result = new StarsResultWithNext();
            var client = _restClient;
            while (true)
            {
                StarsResultWithNext starsOnePage = await client.GetTaskAsync<StarsResultWithNext>(_restRequest);
                for (int j = 0; j < starsOnePage.Results.Count; j++)
                {
                    starsOnePage.Results[j].Index = result.Count+j+1;
                }
                result.Results.AddRange(starsOnePage.Results);
                result.Count += starsOnePage.Results.Count;
                if (starsOnePage.Next != null) client = new RestClient(starsOnePage.Next);
                else break;
            }
            return _mapper.Map<StarsResultWithNext, StarsResult>(result);
        }

        public async Task<StarsResult> GetStarsAsync()
        {
            StarsResult result = await _restClient.GetTaskAsync<StarsResult>(_restRequest);
            setIndex(result);
            return result;
        }

        public StarsResult GetStarsSync()
        {
            StarsResult result = _restClient.Execute<StarsResult>(_restRequest).Data;
            setIndex(result);
            return result;
        }
        private void setIndex(StarsResult starsRes)
        {
            for (int i = 0; i < starsRes.Results.Count; i++)
            {
                starsRes.Results[i].Index = i + 1;
            }
        }
    }
}
