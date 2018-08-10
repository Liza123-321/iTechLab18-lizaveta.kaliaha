using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task2WebAPI.Models;

namespace task2WebAPI.Services
{
    public interface IStarsService
    {
        ResStars GetStarsSync(string url);
        Task<ResStars> GetStarsAsync(string url);
        Task<ResStars> GetAllStarsAsync(string url);
    }
}
